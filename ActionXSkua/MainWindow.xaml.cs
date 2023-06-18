using Skua.Core.Interfaces;
using System.Windows;
using System.ComponentModel;
using Skua.WPF;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ExamplePlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        public static MainWindow Instance { get; } = new();
        public static IScriptInterface Bot => IScriptInterface.Instance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void NameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Bot != null && NameChangeTxt.Text.Length != 0)
            {
                Bot.Options.CustomName = NameChangeTxt.Text;
            }
        }
    }
}
