using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace CancerNidalee
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.

        //Human
        public static Spell.Skillshot Javelin { get; private set; }
        public static Spell.Skillshot Bushwack { get; private set; }
        public static Spell.Targeted Primalsurge { get; private set; }
        //Cougar
        public static Spell.Active Takedown { get; private set; }
        public static Spell.Active Pounce { get; private set; }
        public static Spell.Active Swipe { get; private set; }
        //Transform
        public static Spell.Active Aspectofcougar { get; private set; }

        static SpellManager()
        {
            // Initialize Humanspells
            Javelin = new Spell.Skillshot(SpellSlot.Q, 1500, SkillShotType.Linear);
            Bushwack = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular);
            Primalsurge = new Spell.Targeted(SpellSlot.E, 650);
            // Initialize Cougarspells
            Takedown = new Spell.Active(SpellSlot.Q, 200);
            Pounce = new Spell.Active(SpellSlot.W, 375);
            Swipe = new Spell.Active(SpellSlot.E, 275);
            // Initialize Transformspell
            Aspectofcougar = new Spell.Active(SpellSlot.R);
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

    }
}
