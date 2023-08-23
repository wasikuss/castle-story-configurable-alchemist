using System.IO;
using Brix.Lua;
using HarmonyLib;
using MoonSharp.Interpreter;
using UnityEngine;

namespace CastleStory_ConfigurableAlchemist {
    [HarmonyPatch(typeof(LuaLoader), nameof(LuaLoader.LoadUserKeyBindingLuaFile))]
    public class LuaLoaderPatch { 
        static FileSystemWatcher watcher;
        
        static void Prefix() {
            LoadConfig();

            watcher = new FileSystemWatcher("Info/Lua/modconf")
            {
                Filter = "configurable_alchemist.lua",
                EnableRaisingEvents = true
            };
            watcher.Changed += (object sender, FileSystemEventArgs e) => {
                Debug.Log("Reloading configurable alchemist config.");
                LoadConfig();
            };
        }

        static void LoadConfig() {
            DynValue result = LuaLoader.Load(out Script script, "modconf/configurable_alchemist.lua");
            ConfigurableAlchemist.Instance.Start(Config.Config.Parse(result.Table));
            Script.Kill(ref script);
        }
    }
}
