using SplashKitSDK;
using System;

namespace BoatBattle
{
    public class LargeBoat : Boat
    {

        public LargeBoat()
        {
            BoatName = "Large Boat";
            Bitmap = SplashKit.BitmapNamed("LargeBoat");
            Health = 3;
        }

        public override void Damaged(int i)
        {
            if (Select)
            {
                Health -= i;
                SplashKit.DrawText("Boat damaged: Health -" + i, Color.Red, "Bold font.", 25, PosX + 111, PosY + 5);

                if (Health <= 0)
                {
                    SplashKit.DrawText(BoatName + " has SUNK", Color.Red, "Bold font.", 25, PosX + 111, PosY + 15);
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

                posXMargin = _x + 391;
                posYMargin = _y + 340;

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