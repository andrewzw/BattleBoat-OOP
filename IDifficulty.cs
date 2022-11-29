using SplashKitSDK;
using System.Collections.Generic;

namespace BoatBattle
{
    public interface IDifficulty
    {
        public void UseDifficulty(int rounds, List<Boat> boats);

        public int GetDifficulty();

        public void RandomizeSpawn(List<Boat> boats); //Randomizes spawn location of boats on window

    }
}
