using EloBuddy.SDK;

namespace CancerNidalee.Modes
{
    public abstract class ModeBase
    {
        // Change the spell type to whatever type you used in the SpellManager
        // here to have full features of that spells, if you don't need that,
        // just change it to Spell.SpellBase, this way it's dynamic with still
        // the most needed functions
        protected Spell.Skillshot Javelin
        {
            get { return SpellManager.Javelin; }
        }
        protected Spell.Skillshot Bushwack
        {
            get { return SpellManager.Bushwack; }
        }
        protected Spell.Targeted Primalsurge
        {
            get { return SpellManager.Primalsurge; }
        }
        protected Spell.Active Takedown
        {
            get { return SpellManager.Takedown; }
        }
        protected Spell.Active Pounce
        {
            get { return SpellManager.Pounce; }
        }
        protected Spell.Active Swipe
        {
            get { return SpellManager.Swipe; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
