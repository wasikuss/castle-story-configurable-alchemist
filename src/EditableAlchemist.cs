using UnityEngine;
using System.Collections;

namespace CastleStory_ConfigurableAlchemist {
    class ConfigurableAlchemist {
        static private ConfigurableAlchemist _instance;
        public static ConfigurableAlchemist Instance {
            get {
                _instance ??= new ConfigurableAlchemist();
                return _instance;
            }
        }

        private ConfigurableAlchemist() { }

        public Config.Config CurrentConfig { get; private set; }

        public void Start(Config.Config config) {
            CurrentConfig = config;
        }
    }
}
