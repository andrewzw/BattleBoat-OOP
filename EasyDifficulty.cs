using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace BoatBattle
{
    public class EasyDifficulty :  IDifficulty
    {

        public void UseDifficulty(int rounds, List<Boat> boats)
        {
            Random random = new Random();      
            if (rounds > random.Next(1, 75))
            {
                RandomizeSpawn(boats);
            }
        }

        public int GetDifficulty()
        {
            return 1;
        }

        public void RandomizeSpawn(List<Boat> boats) //Randomizes spawn location of boats on window
        {
            for (int i = 0; i < boats.Count; i++)
            {
                foreach (Boat b in boats)
                {
                    if (SplashKit.BitmapCollision(boats[i].Bitmap, boats[i].PosX, boats[i].PosY, b.Bitmap, b.PosX, b.PosY))
                    {
                        b.Randomize();
                    }
                }
            }

            SplashKit.DrawBitmap(SplashKit.BitmapNamed("OceanImg"), 0, 0); //Bg img
        }
    }
}
