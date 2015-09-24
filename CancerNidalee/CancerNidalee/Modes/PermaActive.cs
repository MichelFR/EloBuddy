using EloBuddy;
using EloBuddy.SDK;

using Settings = CancerNidalee.Config.Modes;

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
            
        
        }
    }
}
