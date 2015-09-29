using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace CancerNidalee
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "CancerNidalee";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to CancerNidalee Addon!");
            Menu.AddLabel("Im Cancerous and i dont got Cancer!");
            Menu.AddLabel("I Dont want to make fun of people who got Cancer,");
            Menu.AddLabel("i just wanted to say that this addon is badass just like the disease!");
            

           // Initialize the modes
           Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseHQ", new CheckBox("Use Human Q"));
                    _useW = Menu.Add("comboUseHW", new CheckBox("Use Human W"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {

                static Misc()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Misc");
                    foreach (var hero in HeroManager.Allies)
                    {
                        Menu.Add("healallies", new CheckBox("Heal " + hero.ChampionName));
                    }
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseHumanQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseHumanW
                {
                    get { return Menu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseHumanQ", new CheckBox("Use Human Q"));
                    Menu.Add("harassUseHumanW", new CheckBox("Use Human W", false));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
