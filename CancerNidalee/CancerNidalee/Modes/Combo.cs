using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

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
        private static bool TargetHunted(Obj_AI_Base target)
        {
            return target.HasBuff("nidaleepassivehunted");
        }
        private static float CougarDamage(Obj_AI_Base target)
        {
            var damage = 0d;

            if (Settings.UseCQ)
                damage += ObjectManager.Player.GetSpellDamage(target, SpellSlot.Q);
            if (Settings.UseCW) //w.IsReady
                damage += ObjectManager.Player.GetSpellDamage(target, SpellSlot.W);
            if (Settings.UseCE)
                damage += ObjectManager.Player.GetSpellDamage(target, SpellSlot.E);

            return (float)damage;
        }

        public override void Execute()
        {
            var CougarForm = Q.Name == "Takedown";
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            

            // Check if Q2 is ready (on unit)
            if (Q2.IsReady() && Settings.UseCQ && target.Distance(ObjectManager.Player.ServerPosition, true) <= Q2.RangeSquared + 150 * 150)
            {
                Q2.Cast(target.Position);
                if (Player.HasBuff("Takedown"))
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
            }
            // Check is pounce is ready 
            if (W2.IsReady() && Settings.UseCW &&
               (target.Distance(ObjectManager.Player.ServerPosition, true) > 275 * 275))
            {
                if (TargetHunted(target) & target.Distance(ObjectManager.Player.ServerPosition, true) <= 735 * 735)
                {
                    if (Q2.IsReady())
                        Q2.Cast();

                    W.Cast(target.Position);
                }
                else if (target.Distance(ObjectManager.Player.ServerPosition, true) <= 400 * 400)
                {
                    if (Q2.IsReady())
                        Q2.Cast();

                    W.Cast(target.ServerPosition);
                }
            }
            // Check if swipe is ready
            if (Swipe.IsReady() && _mainMenu.Item("usecougare").GetValue<bool>())
            {
                if (target.Distance(Me.ServerPosition, true) <= Swipe.RangeSqr)
                {
                    if (!W2.IsReady())
                        E2.Cast(target.ServerPosition);
                }
            }

            // Switch to human form if can kill in aa and cougar skill not available      
            if (!W2.IsReady() && !E2.IsReady() && !Q2.IsReady())
            {
                if (target.Distance(ObjectManager.Player.ServerPosition, true) > Q2.RangeSquared)
                {
                    if (Settings.UseR)
                    {
                        if (target.Distance(ObjectManager.Player.ServerPosition, true) <= ObjectManager.Player.AttackRange * ObjectManager.Player.AttackRange + 50 * 50)
                        {
                            if (R.IsReady())
                                R.Cast();
                        }
                    }
                }
            }
        
            // human Q 
            if (!CougarForm && target.IsValidTarget(Q.Range))
            {
                if (target.IsValidTarget() && Q.IsReady() && Settings.UseHQ)
                {
                    Q.Cast(target);
                }
            }
            // Check bushwack and cast underneath targets feet.
            if (W.IsReady() && Settings.UseHW)
            {
                if (target.Distance(ObjectManager.Player.ServerPosition, true) <= W.RangeSquared)
                {
                    W.Cast();
                }
            }
        }
    }
}