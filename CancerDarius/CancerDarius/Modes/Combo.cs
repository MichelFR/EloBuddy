using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = CancerDarius.Config.Modes.Combo;

namespace CancerDarius.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (E.IsReady() && E.IsInRange(target) && target != null)
                {
                    E.Cast(target);
                }
            }
            if (Settings.UseW && W.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
                if (W.IsReady() && target != null)
                {
                    W.Cast();
                }
            }
            if (Settings.UseQ && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (Q.IsReady() && Q.IsInRange(target) && target != null)
                {
                    Q.Cast(target);
                }
            }
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