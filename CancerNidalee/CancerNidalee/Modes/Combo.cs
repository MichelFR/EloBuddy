using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

// Using the config like this makes your life easier, trust me
using Settings = CancerNidalee.Config.Modes.Combo;

namespace CancerNidalee.Modes
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
            var CougarForm = Q.Name == "Takedown";
            if (Settings.UseHQ && Q.IsReady() && !CougarForm)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (Q.IsReady() && Q.IsInRange(target) && target != null)
                {
                   Q.Cast(target);
                }
            }
            if (Settings.UseHW && W.IsReady() && !CougarForm)
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
                if (W.IsReady() && target != null)
                {
                    W.Cast(target.Position);
                }
            }
            // transform always when a target is marked 
            if (Settings.UseR && R.IsReady() && CougarForm)
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
                if (W.IsReady() && target != null && target.HasBuff("nidaleepassivehunted") && target.Distance(ObjectManager.Player.Position) <= 750)
                {
                    W.Cast(target.Position);
                }
            }
            if (CougarForm && W.IsReady() && Settings.UseCW)
            {
                var heroes = HeroManager.Enemies.Where(x => x.IsValidTarget() && !x.IsZombie && x.HasBuff("nidaleepassivehunted") && x.Distance(ObjectManager.Player.Position) <= 750);
                foreach (var x in heroes)
                {
                    W.Cast(x.Position);
                    return;
                }
                var targets = HeroManager.Enemies.Where(x => x.IsValidTarget() && !x.IsZombie && !x.HasBuff("nidaleepassivehunted") && x.Distance(ObjectManager.Player.Position) <= 375 + ObjectManager.Player.BoundingRadius);
                foreach (var x in heroes)
                {
                    W.Cast(x.Position);
                    return;
                }
            }
        }
    }
}