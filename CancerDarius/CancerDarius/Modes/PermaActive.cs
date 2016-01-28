using EloBuddy;
using EloBuddy.SDK;

using Settings = CancerDarius.Config.Modes.Killsteal;

namespace CancerDarius.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }
        public override void Execute()
        {
            if (Settings.UseR && R.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);

                if (target.IsValidTarget(R.Range) && !target.IsZombie)
                {
                    int PassiveCounter = target.GetBuffCount("dariushemo") <= 0 ? 0 : target.GetBuffCount("dariushemo");
                        if (SpellManager.RDmg(target, PassiveCounter) >= target.Health+ target.TotalShieldHealth() + SpellManager.PassiveDmg(target, 1))
                        {
                            if (!target.HasBuffOfType(BuffType.Invulnerability)
                                || !target.HasBuffOfType(BuffType.SpellShield) 
                                || !target.HasBuff("kindredrnodeathbuff") //Kindred Ult
                                || !target.HasBuff("BlitzcrankManaBarrierCD") //Blitz Passive
                                || !target.HasBuff("ManaBarrier") //Blitz Passive
                                || !target.HasBuff("FioraW") //Fiora W
                                || !target.HasBuff("JudicatorIntervention") //Kayle R
                                || !target.HasBuff("UndyingRage") //Trynd R
                                || !target.HasBuff("BardRStasis") //Bard R
                                || !target.HasBuff("ChronoShift") //Zilean R
                                )
                            {
                                R.Cast(target);
                            }
                        }
                }
            }
        }
    }
}
