using SplashKitSDK;
using System;

namespace BoatBattle
{
    public class ExtraBullets : Abilities
    {

        public ExtraBullets()
        {
            AbilityName = "ExtraBullets";
            AbilityBitmap = SplashKit.BitmapNamed("ExtraBullets");
        }

        public override void ShootAbility(Player p)
        {         
            p.Bullets += 2;
            Console.WriteLine("Used: " + AbilityName + " ,bullet count increased by 2");
        }

    }
}
