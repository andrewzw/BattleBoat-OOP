using SplashKitSDK;


namespace BoatBattle
{
    public abstract class Abilities
    {
        private string _abilityName;
        private Bitmap _abilityBitmap;
        public Abilities()
        {
            _abilityName = "";
        }

        public string AbilityName
        {
            get { return _abilityName; }
            set { _abilityName = value; }
        }

        public Bitmap AbilityBitmap
        {
            get { return _abilityBitmap; }
            set { _abilityBitmap = value; }
        }

        public abstract void ShootAbility(Player p);
    }
}
