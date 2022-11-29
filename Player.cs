using System;


namespace BoatBattle
{
    public class Player
    {
        private string _name;
        private int _bullets;
        private int _damage;
        private Abilities _ability;
        private int _abilityCount;
        public Player()
        {
            _name = "Player";
            _bullets = 30;
            _damage = 1;
            _ability = new PowerBullets();
            _abilityCount = 3;
        }

        public void ShootAbility()
        {
            if(_abilityCount > 0)
            { 
                if (_ability == null)
                {
                    Console.WriteLine("You have not chosen an ability, use button \n Z[PowerBullets]\n X[ExtraBullets]\n C[ExtraAbility]\n");
                }
                else
                {
                    _ability.ShootAbility(this);
                    _abilityCount -= 1;
                
                    Console.WriteLine("Ability Count:" + _abilityCount + " left.");
                }
            }

            if (_abilityCount < 1)
            {
                Console.WriteLine("Ran out of abilities to use");
            }
        }

        public void IncreaseAbilityCount(int i)
        {
            _abilityCount += i;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Bullets
        {
            get { return _bullets; }
            set { _bullets = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public Abilities Ability
        {
            get { return _ability; }
            set { _ability = value; }
        }

        public int AbilityCount
        {
            get { return _abilityCount; }
        }


    }
}
