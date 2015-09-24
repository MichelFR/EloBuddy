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
            /*
            if (Settings.UseR && R.IsReady())
            {
                var target = TargetSelector.GetTarget(R.Range, DamageType.Physical);
                if (target != null && R.IsInRange(target)) 
                {
                    R.Cast(target);
                }
            }
            */
        }
    }
}
