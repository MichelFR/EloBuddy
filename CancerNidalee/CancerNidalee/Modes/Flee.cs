using EloBuddy;
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
            if (!CougarForm && R.IsReady() && W2.IsReady())
            {
                R.Cast();
                W.Cast(Game.CursorPos);
            }
            if (CougarForm && R.IsReady() && W2.IsReady())
            {
                W.Cast(Game.CursorPos);
            }
        }
    }
}
