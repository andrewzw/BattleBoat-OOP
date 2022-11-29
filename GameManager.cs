using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace BoatBattle
{
    public class GameManager 
    {

        private int _rounds;
        private List<Boat> _boats;
        private Player _player;
        private IDifficulty _difficulty;
        private Config _config;

        public GameManager()
        {
            _boats = new List<Boat>();
            _player = new Player();
            _rounds = 1;
            _difficulty = new EasyDifficulty();
            _config = new Config();
        }

        public void AddBoat(Boat b)
        {
            _boats.Add(b);
        }

        public void ShootAt(Point2D pt)
        {
            Player.Bullets -= 1;
            List<Boat> _boatsToDraw = new List<Boat>();
            bool missed = true;
            MouseLocation(pt); //Check if mouse location is at boat

            foreach (Boat b in _boats)
            {
                if (b.Select) //Check if boat is selected
                {
                    missed = false;
                    b.Damaged(_player.Damage); //Health -1 if b.Select == true
                    if (b.Health < 1)
                    {
                        _boatsToDraw.Add(b); //Draw boats when health == 0
                    }
                }
            }

            foreach (Boat b in _boatsToDraw)
            {
                SplashKit.DrawBitmap(b.Bitmap, b.PosX, b.PosY);
                _boats.Remove(b);
            }

            if (missed)
            {
                Console.WriteLine("You missed");
                _rounds += 1;
                _difficulty.UseDifficulty(_rounds, _boats);
            }
        }
        public void MouseLocation(Point2D pt)
        {
            foreach (Boat b in _boats)
            {
                if (SplashKit.BitmapPointCollision(b.Bitmap, b.PosX, b.PosY, pt.X, pt.Y))
                {
                    b.Select = true;
                }
                else
                {
                    b.Select = false; //when player miss
                }
            }
        }
        public void SetDifficulty(IDifficulty diff)
        {
            _difficulty = diff;
            _difficulty.GetDifficulty(); //print diff
        }
        public void UseAbility(Abilities a)
        {
            _player.Ability = a;
            _player.ShootAbility();
        }
        public Config Config
        {
            get { return _config; }
        }

        public int Rounds
        {
            get { return _rounds; }
        }

        public Player Player
        {
            get { return _player; }
        }

        public IDifficulty Difficulty
        {
            get { return _difficulty; }
        }

        public List<Boat> Boats
        {
            get { return _boats; }
        }

        public void Test()
        {
            foreach (Boat b in _boats)
            {
                SplashKit.DrawBitmap(b.Bitmap, b.PosX, b.PosY);
            }
        }

    }
}
