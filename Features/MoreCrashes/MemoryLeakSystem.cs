using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace QualityOfDeath.Features.MoreCrashes
{
    public class MemoryLeakSystem : ModSystem
    {
        public static List<byte[]> LeakedMemory = new();
        private int _timer;
        private readonly Random _leakRng = new();

        public override void PostUpdateEverything()
        {
            _timer++;
            if (_timer >= 60)
            {
                _timer = 0;
                if (_leakRng.Next(500) == 0)
                {
                    LeakedMemory.Add(new byte[10_000_000]);
                }
            }
        }
    }
}
