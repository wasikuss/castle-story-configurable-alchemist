using MoonSharp.Interpreter;

namespace CastleStory_ConfigurableAlchemist.Config {
    struct Config {
        static public readonly Config Default = new(10, 3, false);

        public int MaxAmmo { get; }
        public int DefaultAmmo { get; }
        public bool IsGlobal { get; }

        public Config(int maxAmmo, int defaultAmmo, bool isGlobal) {
            MaxAmmo = maxAmmo;
            DefaultAmmo = defaultAmmo;
            IsGlobal = isGlobal;
        }

        static public Config Parse(Table table) {
            int maxAmmo, defaultAmmo;
            maxAmmo = (int)table.Get("maxAmmo").Number;
            defaultAmmo = (int)table.Get("defaultAmmo").Number;
            bool isGlobal = table.Get("isGlobal").Boolean;
            return new Config(maxAmmo, defaultAmmo, isGlobal);
        }
    }
}
