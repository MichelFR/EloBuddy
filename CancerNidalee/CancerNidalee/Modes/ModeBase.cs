﻿using EloBuddy.SDK;

namespace CancerNidalee.Modes
{
    public abstract class ModeBase
    {
        // Change the spell type to whatever type you used in the SpellManager
        // here to have full features of that spells, if you don't need that,
        // just change it to Spell.SpellBase, this way it's dynamic with still
        // the most needed functions
        protected Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        protected Spell.Targeted E
        {
            get { return SpellManager.E; }
        }
        protected Spell.Active Q2
        {
            get { return SpellManager.Q2; }
        }
        protected Spell.Active W2
        {
            get { return SpellManager.W2; }
        }
        protected Spell.Skillshot E2
        {
            get { return SpellManager.E2; }
        }
        protected Spell.Active R
        {
            get { return SpellManager.R; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
