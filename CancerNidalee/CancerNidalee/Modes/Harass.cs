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
            if (Settings.UseHumanQ && Javelin.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Javelin.IsReady())
            {
                var target = TargetSelector.GetTarget(Javelin.Range, DamageType.Physical);
                if (Javelin.IsReady() && Javelin.IsInRange(target) && target != null)
                {
                    Javelin.Cast(target);
                }
            }
            if (Settings.UseHumanW && Bushwack.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Javelin.IsReady())
            {
                var target = TargetSelector.GetTarget(Bushwack.Range, DamageType.Physical);
                if (Bushwack.IsReady() && target != null)
                {
                    Bushwack.Cast();
                }
            }
        }
    }
}
