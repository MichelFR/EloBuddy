using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = CancerNidalee.Config.Modes.Harass;

namespace CancerNidalee.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            if (Settings.UseHumanQ && Q.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (Q.IsReady() && Q.IsInRange(target) && target != null)
                {
                    Q.Cast(target);
                }
            }
            if (Settings.UseHumanW && W.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
                if (W.IsReady() && target != null)
                {
                    W.Cast();
                }
            }
        }
    }
}
