using EloBuddy.SDK;
using System.Linq;

using Settings = CancerNidalee.Config.Modes.Misc;

namespace CancerNidalee.Modes
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
            var CougarForm = Q.Name == "Takedown";
            if (!CougarForm && E.IsReady() && Settings.UseHeal)
            {
                foreach (var target in HeroManager.Allies.Where(target => target.IsValidTarget(E.Range) && !target.IsZombie))
                {
                    if (target.Health * 100 / target.MaxHealth <= Settings.HpHeal)
                    {
                        E.Cast(target);
                    }
                }
            }
        }
    }
}
