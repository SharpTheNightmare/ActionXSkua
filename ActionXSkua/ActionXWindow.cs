﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using Skua.Core.Interfaces;
using Skua.WPF.Flash;

namespace ActionXSkua
{
    public partial class ActionXWindow : Form
    {
        #region Declares
        public static ActionXWindow Instance { get; } = new();
        public static IScriptInterface Bot => IScriptInterface.Instance;


        private TcpListener TCPServer;
        private TcpClient? TCPClient;
        private NetworkStream? ThisStream;
        public MyList<Client> Clients = new();
        private static string IP => Instance.HostIPTextBox.Text;
        private static string Port => Instance.PortTextBox.Value.ToString();
        private string? HostPName;
        public bool IsOn
        {
            get
            {
                if (ClientCheckBox.Checked)
                {
                    return StartConButton.Text == "Disconnect";
                }
                else
                {
                    return StartConButton.Text == "Stop";
                }
            }
        }
        #endregion

        public ActionXWindow()
        {
            InitializeComponent();
            Clients.OnAdd += ClientsAdded;
            Clients.OnRemove += ClientsRemoved;
        }

        private void ActionX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private async void StartConButton_Click(object sender, EventArgs e)
        {
            if (!ClientCheckBox.Checked)
            {
                if (!IsOn)
                {
                    DoStartUI();
                    await Task.Run(delegate ()
                    {
                        StartHost();
                    });
                }
                else
                {
                    DoStopUI();
                    await Task.Run(delegate ()
                    {
                        StopHost();
                    });
                    AddLog("All connection closed");
                }
            }
            else
            {
                if (!IsOn)
                {
                    DoStartUI();
                    await Task.Run(delegate ()
                    {
                        StartHost();
                    });
                }
                DoStopUI();
                await Task.Run(delegate ()
                {
                    StopHost();
                });
            }
        }

        #region Connection
        private async void StartHost()
        {
            if (!ClientCheckBox.Checked)
            {
                try
                {
                    int port = int.Parse(Port);
                    IPAddress? localAddr = IPAddress.Parse(IP);
                    TCPServer = new TcpListener(localAddr, port);
                    TCPServer.Start();
                    for (; ; )
                    {
                        TcpClient? tcpClient = await TCPServer.AcceptTcpClientAsync();
                        TcpClient? client = tcpClient;
                        AddLog("[Client connected]");
                        NetworkStream? stream = client.GetStream();
                        Clients.Add(new Client(client, stream));
                        if (Bot.Player.LoggedIn && Bot.Map.Loaded)
                        {
                            SendHCMSG(string.Format("$HostName:{0}", Bot.Player.Username), "h");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("Cannot access a disposed object"))
                    {
                        AddLog("TCP accepter terminated");
                    }
                    else if (ex.Message.StartsWith("Only one usage of each socket address (protocol/network address/port) is normally permitted"))
                    {
                        StopHost();
                        DoStopUI();
                        AddLog("Address/port already been used");
                    }
                    else if (ex.Message.StartsWith("The I/O operation has been aborted because of either a thread exit or an application request."))
                    {
                        StopHost();
                        DoStopUI();
                        AddLog("I/O operation has been aborted. (Server was closed)");
                    }
                    else
                    {
                        StopHost();
                        DoStopUI();
                        AddLog(string.Format("Error (StartHost): {0}", ex));
                    }
                }
            }
            else
            {
                try
                {
                    string? server = IP;
                    int port = int.Parse(Port);
                    TCPClient = new TcpClient(server, port);
                    ThisStream = TCPClient.GetStream();
                    StartConButton.Enabled = true;
                    ClientListen();
                }
                catch (Exception ex)
                {
                    ConnectErrorHandle();
                    if (ex.Message.StartsWith("No connection could be made because the target machine actively refused it"))
                    {
                        AddLog("Host not found");
                    }
                    else
                    {
                        AddLog(string.Format("Error (connectClient): {0}", ex));
                    }
                }
            }
        }

        private void StopHost()
        {
            if (!ClientCheckBox.Checked)
            {
                TCPServer.Stop();
            }
            else
            {
                if (TCPClient != null)
                {
                    ThisStream.Close();
                    ThisStream = null;
                    TCPClient.Close();
                    TCPClient = null;
                }
            }
        }
        private void DoStartUI()
        {
            if (!ClientCheckBox.Checked)
            {
                ClientCheckBox.Enabled = false;
                ConnectionGB.Enabled = false;
                StartConButton.Text = "Stop";
                Bot.Flash.FlashCall += PacketStream;
            }
            else
            {
                ClientCheckBox.Enabled = false;
                ConnectionGB.Enabled = false;
                StartConButton.Enabled = false;
                StartConButton.Text = "Disconnect";
            }
        }

        private void DoStopUI()
        {
            if (!ClientCheckBox.Checked)
            {
                ClientCheckBox.Enabled = true;
                ConnectionGB.Enabled = true;
                StartConButton.Text = "Start";
                Bot.Flash.FlashCall -= PacketStream;
            }
            else
            {
                ClientCheckBox.Enabled = true;
                ConnectionGB.Enabled = true;
                StartConButton.Enabled = true;
                StartConButton.Text = "Connect";
            }
        }

        private void ConnectErrorHandle()
        {
            TCPClient = null;
            ThisStream = null;
            DoStopUI();
        }

        private void ClientsAdded(object sender, EventArgs e)
        {
            StartConButton.Enabled = false;
            ConClientTextBox.Text = string.Format("Client Connected: {0}", Clients.Count);
        }

        private void ClientsRemoved(object sender, EventArgs e)
        {
            if (Clients.Count == 0)
            {
                StartConButton.Enabled = true;
            }
            ConClientTextBox.Text = string.Format("Client Connected: {0}", Clients.Count);
        }

        private void ClientListen()
        {
            try
            {
                byte[]? array = new byte[256];
                string? empty = string.Empty;
                int count;
                while ((count = ThisStream.Read(array, 0, array.Length)) != 0)
                {
                    empty = Encoding.ASCII.GetString(array, 0, count);
                    AddLog($" * Received: {empty}");
                    if (empty.StartsWith("%") || empty.StartsWith("$"))
                    {
                        CopyPacket(empty);
                    }
                    if (empty == "disconnect")
                    {
                        break;
                    }
                }
                if (IsOn)
                {
                    StartConButton_Click(this, null);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Unable to read data from the transport connection: An established connection was aborted by the software in your host machine."))
                {
                    AddLog("Client listen terminated");
                }
                else if (ex.Message.StartsWith("Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host."))
                {
                    AddLog("Host server terminated");
                }
                else
                {
                    AddLog($"Error (clientListen): {ex}");
                }
            }
        }

        private void BroadcastMSG_Click(object sender, EventArgs e)
        {
            string? message = BroadcastTextBox.Text;
            if (IsOn && !ClientCheckBox.Checked)
            {
                SendHCMSG(message, "h");
            }
            else if (IsOn && ClientCheckBox.Checked)
            {
                SendHCMSG(message, "c");
            }
        }

        private async void SendHCMSG(string message, string type = "h")
        {
            if (type.ToLower() == "h")
            {
                foreach (Client client in Clients)
                {
                    await client.SendMessage(message);
                }
            }
            else if (type.ToLower() == "c")
            {
                try
                {
                    byte[]? bytes = Encoding.ASCII.GetBytes(message);
                    ThisStream.Write(bytes, 0, bytes.Length);
                    AddLog($" * {Bot.Player.Username}: {message}");
                }
                catch (Exception arg)
                {
                    AddLog($"Error (ClientsendMsg): {arg}");
                }
            }
        }

        public void AddLog(string text)
        {
            TextBox? textBox = LogTextBox;
            textBox.Text = textBox.Text + text + "\r\n";
        }
        #endregion

        #region CheckBoxes
        private void ClientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ClientCheckBox.Checked)
            {
                ConnectionGB.Text = "Connect To";
                SendOptionsGB.Text = "Copy Options";
                StartConButton.Text = "Connect";
                OptionsGB.Text = "Client Options";
                ConClientTextBox.Visible = false;
                HostTooCheckBox.Visible = false;
                UnlockLabel.Visible = true;
                AutoAttackCheckBox.Enabled = false;
                InfiniteRangeCheckBox.Enabled = false;
                SkipCutsceneCheckBox.Enabled = false;
                ProvokeCheckBox.Enabled = false;
                LagKillerCheckBox.Enabled = false;
                HidePlayersCheckBox.Enabled = false;

                AutoAttackCheckBox.MouseUp += CheckBox_MouseUp;
                InfiniteRangeCheckBox.MouseUp += CheckBox_MouseUp;
                SkipCutsceneCheckBox.MouseUp += CheckBox_MouseUp;
                ProvokeCheckBox.MouseUp += CheckBox_MouseUp;
                LagKillerCheckBox.MouseUp += CheckBox_MouseUp;
                HidePlayersCheckBox.MouseUp += CheckBox_MouseUp;

                AutoAttackCheckBox.CheckedChanged += CheckBox_CheckedChanged;
                InfiniteRangeCheckBox.CheckedChanged += CheckBox_CheckedChanged;
                SkipCutsceneCheckBox.CheckedChanged += CheckBox_CheckedChanged;
                ProvokeCheckBox.CheckedChanged += CheckBox_CheckedChanged;
                LagKillerCheckBox.CheckedChanged += CheckBox_CheckedChanged;
                HidePlayersCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            }
            else
            {
                ConnectionGB.Text = "Host Address";
                SendOptionsGB.Text = "Send Options";
                StartConButton.Text = "Start";
                OptionsGB.Text = "Send Toggle Options";
                ConClientTextBox.Visible = true;
                HostTooCheckBox.Visible = true;
                UnlockLabel.Visible = false;
                AutoAttackCheckBox.Enabled = true;
                InfiniteRangeCheckBox.Enabled = true;
                SkipCutsceneCheckBox.Enabled = true;
                ProvokeCheckBox.Enabled = true;
                LagKillerCheckBox.Enabled = true;
                HidePlayersCheckBox.Enabled = true;

                AutoAttackCheckBox.MouseUp -= CheckBox_MouseUp;
                InfiniteRangeCheckBox.MouseUp -= CheckBox_MouseUp;
                SkipCutsceneCheckBox.MouseUp -= CheckBox_MouseUp;
                ProvokeCheckBox.MouseUp -= CheckBox_MouseUp;
                LagKillerCheckBox.MouseUp -= CheckBox_MouseUp;
                HidePlayersCheckBox.MouseUp -= CheckBox_MouseUp;

                AutoAttackCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
                InfiniteRangeCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
                SkipCutsceneCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
                ProvokeCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
                LagKillerCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
                HidePlayersCheckBox.CheckedChanged -= CheckBox_CheckedChanged;
            }
        }

        private void UnlockLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AutoAttackCheckBox.Enabled = true;
            InfiniteRangeCheckBox.Enabled = true;
            SkipCutsceneCheckBox.Enabled = true;
            ProvokeCheckBox.Enabled = true;
            LagKillerCheckBox.Enabled = true;
            HidePlayersCheckBox.Enabled = true;
        }

        private void CheckBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CheckBox? checkBox = sender as CheckBox;
                checkBox.Enabled = !checkBox.Enabled;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;
            if (ClientCheckBox.Checked)
            {
                if (checkBox == ProvokeCheckBox)
                {
                    Bot.Options.AggroMonsters = ProvokeCheckBox.Checked;
                    if (!ProvokeCheckBox.Checked && Bot.Player.LoggedIn)
                    {
                        Bot.Map.Jump(Bot.Player.Cell, Bot.Player.Pad);
                        return;
                    }
                }
                else
                {
                    if (checkBox == InfiniteRangeCheckBox)
                    {
                        Bot.Options.InfiniteRange = InfiniteRangeCheckBox.Checked;
                        return;
                    }
                    if (checkBox == LagKillerCheckBox)
                    {
                        Bot.Options.LagKiller = LagKillerCheckBox.Checked;
                        return;
                    }
                    if (checkBox == SkipCutsceneCheckBox)
                    {
                        Bot.Options.SkipCutscenes = SkipCutsceneCheckBox.Checked;
                        return;
                    }
                    if (checkBox == HidePlayersCheckBox)
                    {
                        Bot.Options.HidePlayers = HidePlayersCheckBox.Checked;
                    }
                }
            }
        }

        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {
            LogTextBox.SelectionStart = LogTextBox.TextLength;
            LogTextBox.ScrollToCaret();
        }

        private async void AutoAttackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ClientCheckBox.Checked) SendHCMSG(string.Format("$AutoAttack:{0}", AutoAttackCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked && AutoAttackCheckBox.Checked && Bot.Player.LoggedIn && Bot.Map.Loaded && Bot.Monsters.MapMonsters.Count != 0)
            {
                int i = 1;
                while (i <= 4 && AutoAttackCheckBox.Checked)
                {
                    Bot.Combat.Attack("*");
                    if (Bot.Skills.CanUseSkill(i))
                    {
                        Bot.Skills.UseSkill(i);
                    }
                    await Task.Delay(50);
                    if (i == 4)
                    {
                        i = 0;
                    }
                    i++;
                }
            }
            else if (ClientCheckBox.Checked && AutoAttackCheckBox.Checked && Bot.Player.LoggedIn && Bot.Map.Loaded && Bot.Monsters.MapMonsters.Count != 0)
            {
                int i = 1;
                while (i <= 4 && AutoAttackCheckBox.Checked)
                {
                    Bot.Combat.Attack("*");
                    if (Bot.Skills.CanUseSkill(i))
                    {
                        Bot.Skills.UseSkill(i);
                    }
                    await Task.Delay(50);
                    if (i == 4)
                    {
                        i = 0;
                    }
                    i++;
                }
            }
        }

        private void InfiniteRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SendHCMSG(string.Format("$InfiniteRange:{0}", InfiniteRangeCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked)
            {
                Bot.Options.InfiniteRange = InfiniteRangeCheckBox.Checked;
            }
        }

        private void ProvokeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SendHCMSG(string.Format("$Provoke:{0}", ProvokeCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked)
            {
                Bot.Options.AggroMonsters = ProvokeCheckBox.Checked;
                if (!ProvokeCheckBox.Checked)
                {
                    Bot.Map.Jump(Bot.Player.Cell, Bot.Player.Pad);
                }
            }
        }

        private void LagKillerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SendHCMSG(string.Format("$LagKiller:{0}", LagKillerCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked)
            {
                Bot.Options.LagKiller = LagKillerCheckBox.Checked;
            }
        }

        private void HidePlayersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SendHCMSG(string.Format("$HidePlayer:{0}", HidePlayersCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked)
            {
                Bot.Options.HidePlayers = HidePlayersCheckBox.Checked;
            }
        }

        private void SkipCutsceneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SendHCMSG(string.Format("$SkipCuts:{0}", SkipCutsceneCheckBox.Checked), "h");
            if (HostTooCheckBox.Checked)
            {
                Bot.Options.SkipCutscenes = SkipCutsceneCheckBox.Checked;
            }
        }
        #endregion

        #region Packets
        public void PacketStream(string function, object[] args)
        {
            try
            {
                if (function == "packet")
                {
                    string? raw = args[0].ToString();
                    string[]? msg = raw.Split('%');
                    string? command = msg[3];
                    if (LoadQuestCheckBox.Checked && command == "getQuests")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (AcceptQuestCheckBox.Checked && command == "acceptQuest")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (CompleteQuestCheckBox.Checked && command == "tryQuestComplete")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (GetMapItemCheckBox.Checked && command == "getMapItem")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (MapJoinCheckBox.Checked && ((command == "cmd" && msg[5] == "tfer") || command == "house"))
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (CellJumpCheckBox.Checked && command == "moveToCell")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                    else if (BuyCheckBox.Checked && command == "buyItem")
                    {
                        AddLog(" - Action: " + raw);
                        SendHCMSG(raw, "h");
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error (PacketStream): {ex}");
            }
        }

        private async void CopyPacket(string raw)
        {
            try
            {
                if (raw.StartsWith("$"))
                {
                    if (raw.StartsWith("$HostName"))
                    {
                        HostPName = raw.Split(new char[] { ':' })[1].ToString();
                        SendHCMSG($"{HostPName} Recieved from {Bot.Player.Username}", "c");
                    }
                    else if (raw.StartsWith("$AutoAttack"))
                    {
                        if (AutoAttackCheckBox.Enabled)
                        {
                            bool setToThis = bool.Parse(raw.Split(new char[] { ':' })[1]);
                            AutoAttackCheckBox.Checked = setToThis;
                        }
                    }
                    else if (raw.StartsWith("$Provoke"))
                    {
                        if (ProvokeCheckBox.Enabled)
                        {
                            bool setToThis2 = bool.Parse(raw.Split(new char[] { ':' })[1]);
                            Bot.Options.AggroMonsters = setToThis2;
                            ProvokeCheckBox.Checked = setToThis2;
                            if (!ProvokeCheckBox.Checked)
                            {
                                Bot.Map.Jump(Bot.Player.Cell, Bot.Player.Pad);
                            }
                        }
                    }
                    else if (raw.StartsWith("$InfiniteRange"))
                    {
                        if (InfiniteRangeCheckBox.Enabled)
                        {
                            bool setToThis3 = bool.Parse(raw.Split(new char[] { ':' })[1]);
                            Bot.Options.InfiniteRange = setToThis3;
                            InfiniteRangeCheckBox.Checked = setToThis3;
                        }
                    }
                    else if (raw.StartsWith("$LagKiller"))
                    {
                        if (LagKillerCheckBox.Enabled)
                        {
                            bool setToThis4 = bool.Parse(raw.Split(new char[] { ':' })[1]);
                            Bot.Options.LagKiller = setToThis4;
                            LagKillerCheckBox.Checked = setToThis4;
                        }
                    }
                    else if (raw.StartsWith("$SkipCuts"))
                    {
                        if (SkipCutsceneCheckBox.Enabled)
                        {
                            bool setToThis5 = bool.Parse(raw.Split(new char[] { ':' })[1]);
                            Bot.Options.SkipCutscenes = setToThis5;
                            SkipCutsceneCheckBox.Checked = setToThis5;
                        }
                    }
                    else if (raw.StartsWith("$HidePlayer") && HidePlayersCheckBox.Enabled)
                    {
                        bool setToThis6 = bool.Parse(raw.Split(new char[] { ':' })[1]);
                        Bot.Options.HidePlayers = setToThis6;
                        HidePlayersCheckBox.Checked = setToThis6;
                    }
                }
                else
                {
                    string[]? msg = raw.Split(new char[] { '%' });
                    string? command = msg[3];
                    if (LoadQuestCheckBox.Checked && command == "getQuests")
                    {
                        msg[4] = Bot.Map.RoomID.ToString();
                        string[]? questsId = msg.Skip(5).Take(msg.Length - 6).ToArray<string>();
                        if (questsId.All((string s) => s.All(new Func<char, bool>(char.IsDigit))))
                        {
                            Bot.Quests.Load(questsId.Select(new Func<string, int>(int.Parse)).ToArray());
                        }
                        AddLog(" - Executed: " + string.Join(",", questsId));
                    }
                    else if (AcceptQuestCheckBox.Checked && command == "acceptQuest")
                    {
                        msg[4] = Bot.Map.RoomID.ToString();
                        int questId = Convert.ToInt32(msg[5]);
                        if (!Bot.Quests.IsInProgress(questId))
                        {
                            Bot.Quests.Accept(questId);
                        }
                        AddLog(" - Executed: " + questId);
                    }
                    else if (CompleteQuestCheckBox.Checked && command == "tryQuestComplete")
                    {
                        msg[4] = Bot.Map.RoomID.ToString();
                        string? newPacket2 = string.Join("%", msg);
                        Bot.Send.ClientPacket(newPacket2, "String");
                        AddLog(" - Executed: " + newPacket2);
                    }
                    else if (GetMapItemCheckBox.Checked && command == "getMapItem")
                    {
                        msg[4] = Bot.Map.RoomID.ToString();
                        string? newPacket3 = string.Join("%", msg);
                        Bot.Send.ClientPacket(newPacket3, "String");
                        AddLog(" - Executed: " + newPacket3);
                    }
                    else if (MapJoinCheckBox.Checked && ((command == "cmd" && msg[5] == "tfer") || command == "house"))
                    {
                        if (command == "house")
                        {
                            Bot.Send.Packet(raw, "String");
                        }
                        else
                        {
                            string? map = msg[7];
                            if (Bot.Player.State == 2)
                            {
                                Bot.Map.Jump("Blank", "Spawn");
                            }
                            Bot.Map.Join(map, "Enter", "Spawn");
                            await Task.Delay(100);
                            if (HostPName != null && !Bot.Map.PlayerNames.Contains(HostPName))
                            {
                                Bot.Player.Goto(HostPName);
                            }
                            AddLog(" - Executed: " + map);
                        }
                    }
                    else if (CellJumpCheckBox.Checked && command == "moveToCell")
                    {
                        string? cell = msg[5];
                        string? pad = msg[6];
                        Bot.Map.Jump(cell, pad);
                        AddLog(" - Executed: " + cell + "," + pad);
                    }
                    else if (BuyCheckBox.Checked && command == "buyItem")
                    {
                        int? itemId = int.Parse(msg[5]);
                        int shopId = int.Parse(msg[6]);
                        Bot.Shops.Load(shopId);
                        int i = 0;
                        while (i < 50 && !Bot.Shops.IsLoaded && Bot.Player.LoggedIn && BuyCheckBox.Checked && IsOn)
                        {
                            await Task.Delay(150);
                            int num = i;
                            i = num + 1;
                        }
                        if (Bot.Shops.IsLoaded && Bot.Player.LoggedIn && BuyCheckBox.Checked && IsOn)
                        {
                            string? itemName = Bot.Shops.Items.Find(o => o.ID == itemId).Name;
                            Bot.Shops.BuyItem(itemName);
                            AddLog(" - Executed: Buy " + itemName);
                        }
                        else
                        {
                            AddLog(string.Format(" - Execution Cancelled: : Buy {0}/{1}", shopId, itemId));
                        }
                    }
                }
            }
            catch
            {
                AddLog("[Error: invalid packet]");
            }
        }
        #endregion
    }
}