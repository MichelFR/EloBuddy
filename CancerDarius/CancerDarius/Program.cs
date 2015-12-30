using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System.Net;

using Settings = CancerDarius.Config.Modes.Drawings;

namespace CancerDarius
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Darius";

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                Chat.Print("You're not Darius");
                Chat.Print("Get CAAAAAAAANCERRRR! :D");
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            // Draw range circles of our spells
             if (Settings.ShowQ)
            Circle.Draw(Color.Red, SpellManager.Q.Range, Player.Instance.Position);
            
            if (Settings.ShowW)
            Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            
            if (Settings.ShowE)
            Circle.Draw(Color.Red, SpellManager.E.Range, Player.Instance.Position);
            
            if (Settings.ShowR)
            Circle.Draw(Color.Red, SpellManager.R.Range, Player.Instance.Position);
        }
    }
}
