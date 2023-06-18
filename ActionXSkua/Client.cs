using ActionXSkua;
using System.Net.Sockets;
using System.Text;

namespace ActionXSkua
{
    public class Client
    {
        private TcpClient connection;
        private NetworkStream stream;

        public Client(TcpClient connection, NetworkStream stream)
        {
            this.connection = connection;
            this.stream = stream;
            ListenMessageAndDisconnection();
        }

        private async void ListenMessageAndDisconnection()
        {
            try
            {
                byte[] bytes = new byte[256];
                string data;
                do
                {
                    int num = await stream.ReadAsync(bytes);
                    int i;
                    if ((i = num) == 0)
                    {
                        break;
                    }
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    ActionXWindow.Instance.AddLog(" - Received: " + data);
                }
                while (!(data == "disconnect"));
                CloseConnection();
                bytes = null;
            }
            catch (Exception ex)
            {
                CloseConnection();
                if (ex.Message.StartsWith("Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host."))
                {
                    ActionXWindow.Instance.AddLog("A Connection Was Forcibly Closed");
                }
                else
                {
                    ActionXWindow.Instance.AddLog(string.Format("Error (listenMessageAndDisconnection): {0}", ex));
                }
            }
        }

        public async Task SendMessage(string text)
        {
            try
            {
                if (connection != null)
                {
                    byte[] msg = Encoding.ASCII.GetBytes(text);
                    await stream.WriteAsync(msg);
                    ActionXWindow.Instance.AddLog(" - Sent: " + text);
                }
            }
            catch (Exception ex)
            {
                ActionXWindow.Instance.AddLog(string.Format("Error (sendMessage): {0}", ex));
            }
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
                stream = null;
                ActionXWindow.Instance.Clients.Remove(this);
                ActionXWindow.Instance.AddLog("A Client Connection Closed");
            }
        }
    }
}
