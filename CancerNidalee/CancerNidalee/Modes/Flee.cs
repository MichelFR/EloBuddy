using EloBuddy.SDK;

namespace CancerNidalee.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on flee mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var CougarForm = Q.Name == "Takedown";
            if (!CougarForm && R.IsReady() && CW.IsReady())
                R.Cast();
        }
    }
}
