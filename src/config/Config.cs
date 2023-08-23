using MoonSharp.Interpreter;

namespace CastleStory_ConfigurableAlchemist.Config {
    struct Config {
        public int MaxAmmo { get; }
        public int DefaultAmmo { get; }

        public Config(int maxAmmo, int defaultAmmo) {
            MaxAmmo = maxAmmo;
            DefaultAmmo = defaultAmmo;
        }

        static public Config Parse(Table table) {
            int maxAmmo, defaultAmmo;
            maxAmmo = (int)table.Get("maxAmmo").Number;
            defaultAmmo = (int)table.Get("defaultAmmo").Number;
            return new Config(maxAmmo, defaultAmmo);
        }
    }
}
