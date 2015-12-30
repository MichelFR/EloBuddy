using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace CancerDarius
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "CancerDarius";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to CancerDarius Addon!");
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
                Menu = Config.Menu.AddSubMenu("CancerMode");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                Menu.AddSeparator();

                // Laneclear
                Laneclear.Initialize();
                Menu.AddSeparator();
                
                // Killsteal
                Killsteal.Initialize();
                Menu.AddSeparator();
                
                // Drawings
                Drawings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useE.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"), true);
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"), true);
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"), true);
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R (Automatic use if in Range)", true)); // Default false
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return Menu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["harassUseE"].Cast<CheckBox>().CurrentValue; }
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
                    Menu.Add("harassUseQ", new CheckBox("Use Q"), true);
                    Menu.Add("harassUseW", new CheckBox("Use W"), true);
                    Menu.Add("harassUseE", new CheckBox("Use E"), false);

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 50));
                }

                public static void Initialize()
                {
                }
            }

             public static class Laneclear
            {
                public static bool UseQ
                {
                    get { return Menu["clearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["clearUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["clearMana"].Cast<Slider>().CurrentValue; }
                }

                static Laneclear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Laneclear");
                    Menu.Add("clearUseQ", new CheckBox("Use Q"), true);
                    Menu.Add("clearUseE", new CheckBox("Use E"), false);

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("clearMana", new Slider("Maximum mana usage in percent ({0}%)", 80));
                }

                public static void Initialize()
                {
                }
            }

            public static class Killsteal
            {
                private static readonly CheckBox _useR;

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Killsteal()
                {
                    Menu.AddGroupLabel("Killsteal");
                    _useR = Menu.Add("stealUseR", new CheckBox("Use R", true));
                }

                public static void Initialize()
                {
                }
            }
            
            public static class Drawings
            {
                private static readonly CheckBox _showQ;
                private static readonly CheckBox _showW;
                private static readonly CheckBox _showE;
                private static readonly CheckBox _showR;

                public static bool ShowQ
                {
                    get { return _showQ.CurrentValue; }
                }
                public static bool ShowW
                {
                    get { return _showW.CurrentValue; }
                }
                public static bool ShowE
                {
                    get { return _showE.CurrentValue; }
                }
                public static bool ShowR
                {
                    get { return _showR.CurrentValue; }
                }

                static Drawings()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Drawings");
                    _showQ = Menu.Add("drawingsShowQ", new CheckBox("Draw Q", true));
                    _showW = Menu.Add("drawingsShowW", new CheckBox("Draw W"), false);
                    _showE = Menu.Add("drawingsShowE", new CheckBox("Draw E"), false);
                    _showR = Menu.Add("drawingsShowR", new CheckBox("Draw R", true));
                }

                public static void Initialize()
                {
                }
            }

        }
    }
}
