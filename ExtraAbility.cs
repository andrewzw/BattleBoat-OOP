using SplashKitSDK;
using BoatBattle;
using System;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;
using System.Collections.Generic;
using Color = SplashKitSDK.Color;

namespace BoatBattle
{
    public class ExtraAbility : Abilities
    {

        public ExtraAbility()
        {
            AbilityName = "ExtraAbility";
            AbilityBitmap = SplashKit.BitmapNamed("ExtraAbility");
        }

        public override void ShootAbility(Player p)
        {         
                p.IncreaseAbilityCount(3);
                Console.WriteLine("Used: " + AbilityName + " ,ability count increased by 2");
        }
    }
}
