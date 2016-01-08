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
            // the menu in the Config class!
            if (Settings.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                 if (target.Distance(Player.Instance.ServerPosition) > 250)
                    {
                        if (E.IsReady() && target != null)
                        {
                            E.Cast(target.ServerPosition);
                        }
                    }
            }
            if (Settings.UseW && W.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
                if (W.IsReady() && target != null)
                {
                    if (!target.IsFacing(Player.Instance))
                    W.Cast();
                }
            }
            if (Settings.UseQ && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (Q.IsReady() && target != null)
                {
                    Q.Cast();
                }
            }
            if (Settings.UseR && R.IsReady())
            {
                var target = TargetSelector.GetTarget(R.Range, DamageType.Physical);

                if (target.IsValidTarget(R.Range) && !target.IsZombie)
                {
                    int PassiveCounter = target.GetBuffCount("dariushemo") <= 0 ? 0 : target.GetBuffCount("dariushemo");
                        if (SpellManager.RDmg(target, PassiveCounter) >= target.Health + SpellManager.PassiveDmg(target, 1))
                        {
                            if (!target.HasBuffOfType(BuffType.Invulnerability)
                                && !target.HasBuffOfType(BuffType.SpellShield) 
                                && !target.HasBuff("kindredrnodeathbuff"))
                            {
                                R.Cast(target);
                            }
                        }
                }
            }
        }
    }
}
