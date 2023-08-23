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

        public Config.Config Config { get; private set; }

        public void Start(Config.Config config) {
            Config = config;
            Plugin.Instance.ScheduleCoroutine(HandleConfig());
        }

        private IEnumerator HandleConfig() {
            var backpack = GameObject.Find("PersitantGOs").transform.Find("Factory/Accessories/Backpack").transform;
            var projectileWeapon = backpack.GetComponent<Brix.Game.AI.ProjectileWeapon>();
            projectileWeapon.AmmoCountGetter = Config.DefaultAmmo;
            yield break;
        }
    }
}
