using System;
using SplashKitSDK;
namespace BoatBattle
{
    public class Program
    {
        private enum AbilityTypes
        {
            none,
            PowerBullets,
            ExtraAbility,
            ExtraBullets,
        }
        
        public static void LoadResources()
        {
            //SplashKit.SetResourcesPath("C:/Users/yap_z/Desktop/Custom/BoatBattleV5/Resources/");

            //Abilities Img
            SplashKit.LoadBitmap("ExtraBullets", "ExtraBullets.png");
            SplashKit.LoadBitmap("PowerBullet", "PowerBullet.png");
            SplashKit.LoadBitmap("ExtraAbility", "ExtraAbility.png"); //Change img

            //Boats Img
            SplashKit.LoadBitmap("CivilianBoat", "CivilianBoat.png");
            SplashKit.LoadBitmap("SmallBoat", "SmallBoat.png");
            SplashKit.LoadBitmap("MediumBoat", "MediumBoat.png");
            SplashKit.LoadBitmap("LargeBoat", "LargeBoat.png");

            //Sounds
            SplashKit.LoadMusic("Shooting", "Shooting.mp3");
            SplashKit.LoadMusic("GameOver", "GameOver.mp3");
            SplashKit.LoadMusic("Victory", "Victory.mp3");

            //Other images
            SplashKit.LoadBitmap("VictoryImg", "Victory.png");
            SplashKit.LoadBitmap("DefeatImg", "Defeat.png");
            SplashKit.LoadBitmap("OceanImg", "Ocean.png");
        }

        public static void Main()
        {
            LoadResources();
            //Initialize
            GameManager _game = new GameManager();
            Window window = new Window("BoatBattle", 1280,900);

            //Create Boats
            Boat civilianBoat1 = new CivilianBoat();
            Boat civilianBoat2 = new CivilianBoat();
            Boat smallBoat1 = new SmallBoat();
            Boat smallBoat2 = new SmallBoat();
            Boat smallBoat3 = new SmallBoat();
            Boat mediumBoat1 = new MediumBoat();
            Boat mediumBoat2 = new MediumBoat();
            Boat largeBoat1 = new LargeBoat();

            //Add Boats
            _game.AddBoat(civilianBoat1);
            _game.AddBoat(civilianBoat2);
            _game.AddBoat(smallBoat1);
            _game.AddBoat(smallBoat2);
            _game.AddBoat(smallBoat3);
            _game.AddBoat(mediumBoat1);
            _game.AddBoat(mediumBoat2);
            _game.AddBoat(largeBoat1);

            //Declare AbilityToAdd
            AbilityTypes AbilityToAdd = AbilityTypes.none;

            // run the game loop
            int _x = 1;
            int _limit = 1;
            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                while (_x > 0)
                {
                    Console.Write("Enter username:");
                    _game.Player.Name = Console.ReadLine(); //Set player name        
                    Console.WriteLine("To Choose Difficulty, Use: \t \n 1[EASY]\n 2[MEDIUM]\n 3[HARD]\n");
                    Console.WriteLine("Good Luck " + _game.Player.Name + "\n");
                    _game.Difficulty.RandomizeSpawn(_game.Boats);
                    _game.Config.PrintStatus(window, _game.Rounds, _game.Difficulty, _game.Player, _game.Boats);
                    _x -= 1;
                }

                if (SplashKit.KeyTyped(KeyCode.Num1Key) || SplashKit.KeyTyped(KeyCode.Keypad1))
                {
                    _game.SetDifficulty(new EasyDifficulty());
                    Console.WriteLine("Difficulty Set To: EASY");
                }
                if (SplashKit.KeyTyped(KeyCode.Num2Key) || SplashKit.KeyTyped(KeyCode.Keypad2))
                {
                    _game.SetDifficulty(new MediumDifficulty());
                    Console.WriteLine("Difficulty Set To: MEDIUM");
                }
                if (SplashKit.KeyTyped(KeyCode.Num3Key) || SplashKit.KeyTyped(KeyCode.Keypad3))
                {
                    _game.SetDifficulty(new HardDifficulty());
                    Console.WriteLine("Difficulty Set To: HARD");
                }
                
                //Choose Ability
                Abilities newAbility; //Initialize ability
                
                //Determine which ability to use   
                if (SplashKit.KeyTyped(KeyCode.ZKey))
                {
                    AbilityToAdd = AbilityTypes.PowerBullets;
                    Console.WriteLine("Ability Choosen: Power Bullets");
                }

                if (SplashKit.KeyTyped(KeyCode.XKey))
                {
                    AbilityToAdd = AbilityTypes.ExtraBullets;
                    Console.WriteLine("Ability Choosen: ExtraBullets");
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    AbilityToAdd = AbilityTypes.ExtraAbility;
                    Console.WriteLine("Ability Choosen: ExtraAbility");
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    if (AbilityToAdd == AbilityTypes.PowerBullets)
                    {
                        newAbility = new PowerBullets(); //declare & create ability 
                    }
                    else if (AbilityToAdd == AbilityTypes.ExtraBullets)
                    {
                        newAbility = new ExtraBullets();
                    }
                    else if (AbilityToAdd == AbilityTypes.ExtraAbility && _limit == 1)
                    {
                        newAbility = new ExtraAbility();
                        _limit -= 1;
                    }
                    else
                    {
                        newAbility = null;
                    }

                    _game.UseAbility(newAbility);//Set player ability to newAbility and use it
                }


                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {                  
                    if (_game.Config.CheckStatus(_game.Boats, _game.Player)) //if true
                    {                     
                        _game.Config.ConfigureSound("Shooting", 0.5F, 700);
                        _game.ShootAt(SplashKit.MousePosition());
                    }
                    SplashKit.FillRectangleOnWindow(window, Color.RGBColor(173, 216, 230), 0, 0, 125, 70);
                    _game.Config.PrintStatus(window, _game.Rounds, _game.Difficulty, _game.Player, _game.Boats);                   
                }
                _game.Config.PrintUI(window, _game.Rounds, _game.Difficulty, _game.Player, _game.Boats);

                //PRINT              
                //_game.Test(); //Print boats

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {        
                    _game.Difficulty.RandomizeSpawn(_game.Boats);
                    _game.Test();
                }
                SplashKit.RefreshScreen();
            }

        }

    }
}

