using SplashKitSDK;
using System;

namespace BoatBattle
{
    public class SmallBoat : Boat
    {

        public SmallBoat()
        {
            BoatName = "Small Boat";
            Bitmap = SplashKit.BitmapNamed("SmallBoat");
            Health = 1;
        }

        public override void Damaged(int i)
        {
            if (Select) 
            {
                Health -= i;
                SplashKit.DrawText("Boat damaged: Health -" + i, Color.Red, "Bold font.", 25, PosX + 111, PosY - 10);

                if (Health <= 0)
                {
                    SplashKit.DrawText(BoatName + " has SUNK", Color.Red, "Bold font.", 25, PosX + 111, PosY);
                }
            }

        }

        public override void Randomize()
        {
            Random rnd = new Random();
            float posXMargin = SplashKit.CurrentWindowWidth() + 1;
            float posYMargin = SplashKit.CurrentWindowHeight() + 1;

            while (posXMargin > SplashKit.CurrentWindowWidth() && posYMargin > SplashKit.CurrentWindowHeight())
            {
                int _x = rnd.Next(0, SplashKit.CurrentWindowWidth());
                int _y = rnd.Next(0, SplashKit.CurrentWindowHeight());

                posXMargin = _x + 203;
                posYMargin = _y + 114;

                if (posXMargin <= SplashKit.CurrentWindowWidth() &&
                    posYMargin <= SplashKit.CurrentWindowHeight())
                {
                    PosX = _x;
                    PosY = _y;
                }
            }
        }
    }

}