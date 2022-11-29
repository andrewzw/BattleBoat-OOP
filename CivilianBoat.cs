using SplashKitSDK;
using System;

namespace BoatBattle
{
    public class CivilianBoat : Boat
    {
    
        public CivilianBoat()
        {
            BoatName = "Civilian Boat";        
            Bitmap = SplashKit.BitmapNamed("CivilianBoat");
            Health = 1;
        }

        public override void Damaged(int i)
        {
            if (Select) //Check when select by player
            {
                Health -= i;//Damage boat when select == true
                SplashKit.DrawText("Boat damaged: Health -" + i, Color.Red, "Bold font.", 25, PosX+111, PosY + 5);

                if (Health <= 0)
                {
                    SplashKit.DrawText(BoatName + " has SUNK", Color.Red, "Bold font.", 25, PosX + 111, PosY + 15);
                }
            }
        }

        public override void Randomize() //Randomize PosX PosY
        {
            Random rnd = new Random();
            float posXMargin = SplashKit.CurrentWindowWidth() + 1; //Hard code the margin to start While loop
            float posYMargin = SplashKit.CurrentWindowHeight() + 1;

            while (posXMargin > SplashKit.CurrentWindowWidth() && posYMargin > SplashKit.CurrentWindowHeight())
            {
                int _x = rnd.Next(0, SplashKit.CurrentWindowWidth()); // Returns an `int` value greater in the range 10 <= value < 50
                int _y = rnd.Next(0, SplashKit.CurrentWindowHeight());

                posXMargin = _x + 299; //Margin is set to make sure img stays within window
                posYMargin = _y + 190;
                
                if (posXMargin <= SplashKit.CurrentWindowWidth() && //Set posX posY when it's within window
                    posYMargin <= SplashKit.CurrentWindowHeight())
                {
                    PosX = _x;
                    PosY = _y;
                }

            }
        }
    }
}