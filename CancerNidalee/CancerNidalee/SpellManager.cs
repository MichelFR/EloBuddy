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
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Active R { get; private set; }
        //Cougar
        public static Spell.Active Q2 { get; private set; }
        public static Spell.Active W2 { get; private set; }
        public static Spell.Skillshot E2 { get; private set; }
        public static Spell.Active R2 { get; private set; }

        static SpellManager()
        {
            // Initialize Humanspells
            Q = new Spell.Skillshot(SpellSlot.Q, 1500, SkillShotType.Linear);
            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular);
            E = new Spell.Targeted(SpellSlot.E, 650);
            R = new Spell.Active(SpellSlot.R);
            // Initialize Cougarspells
            Q2 = new Spell.Active(SpellSlot.Q, 200);
            W2 = new Spell.Active(SpellSlot.W, 375);
            E2 = new Spell.Skillshot(SpellSlot.E, 275, SkillShotType.Cone);
            R2 = new Spell.Active(SpellSlot.R);
            // Initialize Transformspell

        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

    }
}
