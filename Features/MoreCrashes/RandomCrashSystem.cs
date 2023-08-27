using Terraria.ModLoader;
using Terraria;
using System;

namespace QualityOfDeath.Features.MoreCrashes
{
    public class RandomCrashSystem : ModSystem
    {
        private int _timer;
        private Random _crashRng = new();

        public override void PostUpdateEverything()
        {
            _timer++;
            if (_timer == 60)
            {
                _timer = 0;
                if (_crashRng.Next(1_000_000) == 0)
                {
                    Main.QueueMainThreadAction(() => throw new EngineException());
                }
            }
        }
    }
}
