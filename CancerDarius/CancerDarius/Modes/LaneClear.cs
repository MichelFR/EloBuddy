using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = CancerDarius.Config.Modes.Laneclear;

namespace CancerDarius.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Q.Range).Where( m => !m.IsDead && m.IsValid && !m.IsInvulnerable);
            
            foreach (var m in minions)
            {
                if (Settings.UseQ)
                {                
                    Q.Cast();
                }
                if (Settings.UseE)
                {
                E.Cast(m.ServerPosition);
                }
            }
        }
    }
}
