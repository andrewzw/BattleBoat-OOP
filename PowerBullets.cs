using System;
using BoatBattle;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;
using System.Collections.Generic;
using SplashKitSDK;
using Color = SplashKitSDK.Color;

namespace BoatBattle
{
    public class PowerBullets : Abilities
    {

        public PowerBullets()
        {
            AbilityName = "PowerBullets";
            AbilityBitmap = SplashKit.BitmapNamed("PowerBullet");
        }

        public override void ShootAbility(Player p)
        {          
            if(p.Damage <= 2)
            {
                p.Damage += 1;
                Console.WriteLine("Used: " + AbilityName + " ,bullet damage increased by 1");
            }
            else
            {
                p.IncreaseAbilityCount(1);
                Console.WriteLine("Your damage is maxed out!"); 
            }
            
        }
    }
}
