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
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseJavelin && Javelin.IsReady())
            {
                var target = TargetSelector.GetTarget(Javelin.Range, DamageType.Magical);
                if (Javelin.IsReady() && Javelin.IsInRange(target) && target != null)
                {
                    Javelin.Cast(target);
                }
            }
            if (Settings.UseBushwack && Bushwack.IsReady())
            {
                var target = TargetSelector.GetTarget(Bushwack.Range, DamageType.Magical);
                if (Bushwack.IsReady() && target != null)
                {
                    Bushwack.Cast();
                }
            } 
        }
    }
}