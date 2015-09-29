using EloBuddy;
using EloBuddy.SDK;

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
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseQ && Q.IsReady() && !CougarForm)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (Q.IsReady() && Q.IsInRange(target) && target != null)
                {
                    Q.Cast(target);
                }
            }
            if (Settings.UseW && W.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
                if (W.IsReady() && target != null)
                {
                    W.Cast();
                }
            } 
        }
    }
}