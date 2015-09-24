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
                var unit = TargetSelector.GetTarget(E.Range, DamageType.Physical);

                if (unit.IsValidTarget(R.Range) && !unit.IsZombie)
                {
                    int rr = unit.GetBuffCount("dariushemo") <= 0 ? 0 : unit.GetBuffCount("dariushemo");
                    if (!unit.HasBuffOfType(BuffType.Invulnerability) && !unit.HasBuffOfType(BuffType.SpellShield))
                    {
                        if (SpellManager.RDmg(unit, rr) >= unit.Health + SpellManager.PassiveDmg(unit, 1))
                        {
                            if (!unit.HasBuffOfType(BuffType.Invulnerability)
                                && !unit.HasBuffOfType(BuffType.SpellShield))
                            {
                                R.Cast(unit);
                            }
                        }
                    }
                }
            }
        }
    }
}
