using Skua.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ActionXSkua
{
    public partial class Loader : ISkuaPlugin
    {
        public static IScriptInterface Bot => IScriptInterface.Instance;

        public string Name => "ActionX Skua";
        public string Author => "SharpTheNightmare";
        public string Description => "Does Something...";

        public List<IOption> Options { get; } = new();

        public IPluginHelper Helper { get; private set; }

        public void Load(IServiceProvider provider, IPluginHelper helper)
        {
            Helper = helper;

            helper.AddMenuButton(Name, () =>
            {
                ActionXWindow.Instance.Show();
                ActionXWindow.Instance.BringToFront();
                ActionXWindow.Instance.Activate();
            });

            Bot?.Log($"{Name} Loaded.");
        }

        public void Unload()
        {
            Bot?.Log($"{Name} Unloaded.");
            Helper?.RemoveMenuButton(Name);
        }
    }
}
