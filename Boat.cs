using SplashKitSDK;
using BoatBattle;
using System;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;


namespace BoatBattle
{
    public abstract class Boat
    {
        private string _boatName;
        private int _health;
        private Point2D _position;
        private bool _select;
        private Bitmap _bitmap;


        public Boat()
        {
            _boatName = "Unknown Boat";
            _health = 1;
            _position.X = 0;
            _position.Y = 0;
            _select = false;
            _bitmap = null;
        }


        public string BoatName
        {
            get { return _boatName; }
            set { _boatName = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public double PosX
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public double PosY
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

       public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }

        public bool Select
        {
            get { return _select; }
            set { _select = value; }
        }

        public abstract void Damaged(int i);
        
        public abstract void Randomize();

    }
}
