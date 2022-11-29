using SplashKitSDK;
using SplashKitSDK;
using System;
using System.Drawing;
using System.Collections.Generic;
using Color = SplashKitSDK.Color;

namespace BoatBattle
{
    public class Config
    {
        public Config()
        {
        }

        public bool CheckStatus(List<Boat> boats, Player player)
        {
            if (boats.Count < 1 && player.Bullets > -1)
            {
                return false;
            }

            if (boats.Count > 0)
            {

                if (player.Bullets < boats.Count)
                {
                    return false;
                }

                else if (player.Bullets > 0)
                {
                    return true;
                }
                return false;

            }
            return false;
        }

        public void PrintUI(Window window, int rounds, IDifficulty difficulty, Player player, List<Boat> boats)
        {
            SplashKit.FillRectangleOnWindow(window, Color.RGBColor(228, 182, 30), 0, 0, 150, 90);
            SplashKit.FillRectangleOnWindow(window, Color.Wheat, 150, 0, 81, 90);
            SplashKit.DrawText("Round:" + rounds, Color.RGBColor(61, 239, 7), "Bold font.", 25, 3, 2);
            SplashKit.DrawText("Difficulty Level:" + difficulty.GetDifficulty(), Color.Black, "Bold font.", 25, 3, 16);
            SplashKit.DrawText("Boat Count:" + boats.Count, Color.Black, "Bold font.", 25, 3, 31);
            SplashKit.DrawText("Bullet(s):" + player.Bullets, Color.Red, "Bold font.", 25, 3, 46);
            SplashKit.DrawText("Bullet(s) Damage:" + player.Damage, Color.Red, "Bold font.", 25, 3, 61);
            SplashKit.DrawText("Ability Count:" + player.AbilityCount, Color.Yellow, "Bold font.", 25, 3, 76);
            if (player.Ability != null)
            {
                SplashKit.DrawBitmap(player.Ability.AbilityBitmap, 153, 3);
            }
            SplashKit.DrawRectangle(Color.Black, 0, 0, 231, 90);
        }

        public void PrintStatus(Window window, int rounds, IDifficulty difficulty, Player player, List<Boat> boats)
        {
            Console.WriteLine("Round: " + rounds);
            PrintUI(window, rounds, difficulty, player,boats);

            if (boats.Count < 1 && player.Bullets > -1)
            {
                Console.WriteLine(boats.Count + " Boats left.");
                Console.WriteLine("Congrats " + player.Name + " , you've won with " + player.Bullets + " bullets left, after " + rounds + " rounds! \n");
                ConfigureSound("Victory", 0.7F, 1500);
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("OceanImg"), 0, 0); //Bg img
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("VictoryImg"), SplashKit.CurrentWindowWidth() * 0.2, SplashKit.CurrentWindowHeight() * 0.2);
                PrintUI(window, rounds, difficulty, player, boats);
            }

            if (boats.Count > 0)
            {
                if (player.Bullets < boats.Count)
                {
                    Console.WriteLine("Try Again " + player.Name + " , you've lost! :(");
                    Console.WriteLine("You have " + player.Bullets + " bullet(s) left ,with " + boats.Count + " more boat(s) to go. \n");
                    ConfigureSound("GameOver", 0.7F, 1000);
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed("OceanImg"), 0, 0); //Bg img
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed("DefeatImg"), SplashKit.CurrentWindowWidth() * 0.3, SplashKit.CurrentWindowHeight() * 0.1);

                }
                else if (player.Bullets > 0)
                {
                    Console.WriteLine("You have " + player.Bullets + " bullet(s) left");
                    Console.WriteLine("and " + boats.Count + "boats left\n");
                }
                else if (player.Bullets == 1)
                {
                    Console.WriteLine("Last Bullet");
                    Console.WriteLine("and " + boats.Count + " boats left\n");
                }

            }
        }

        public void ConfigureSound(string name, float volume, int ms)
        {
            SplashKit.PlayMusic(name);
            SplashKit.SetMusicVolume(volume);
            SplashKit.FadeMusicOut(ms);
        }

    }
}
