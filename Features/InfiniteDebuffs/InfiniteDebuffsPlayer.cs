using System.Collections.Generic;
using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace QualityOfDeath.Features.InfiniteDebuffs
{
    public class InfiniteDebuffsPlayer : ModPlayer
    {
        private static readonly Dictionary<int, int> PotionTypeToDebuffTable = new();
        private readonly Random _debuffIdRng = new();

        public override void PostUpdate()
        {
            base.PostUpdate();
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                foreach (Item item in Player.inventory)
                {
                    if (item.buffType > 0 && item.stack >= 30)
                    {
                        if (!PotionTypeToDebuffTable.ContainsKey(item.type))
                        {
                            PotionTypeToDebuffTable.Add(item.type, DebuffIDs[_debuffIdRng.Next(DebuffIDs.Length)]);
                        }
                        Player.AddBuff(PotionTypeToDebuffTable[item.type], 60, quiet: false);
                    }
                }
            }
        }

        public static readonly int[] DebuffIDs = new int[] {
            BuffID.Poisoned,
            BuffID.PotionSickness,
            BuffID.Darkness,
            BuffID.Cursed,
            BuffID.OnFire,
            BuffID.Tipsy,
            BuffID.Bleeding,
            BuffID.Confused,
            BuffID.Slow,
            BuffID.Weak,
            BuffID.Silenced,
            BuffID.BrokenArmor,
            BuffID.Horrified,
            BuffID.TheTongue,
            BuffID.CursedInferno,
            BuffID.Frostburn,
            BuffID.Chilled,
            BuffID.Frozen,
            BuffID.Burning,
            BuffID.Suffocation,
            BuffID.Ichor,
            BuffID.Venom,
            BuffID.Midas,
            BuffID.Blackout,
            BuffID.WaterCandle,
            BuffID.ChaosState,
            BuffID.ManaSickness,
            BuffID.Wet,
            BuffID.Lovestruck,
            BuffID.Stinky,
            BuffID.Slimed,
            BuffID.Electrified,
            BuffID.MoonLeech,
            BuffID.Rabies,
            BuffID.Webbed,
            BuffID.ShadowFlame,
            BuffID.Stoned,
            BuffID.Dazed,
            BuffID.Obstructed,
            BuffID.VortexDebuff,
            BuffID.BoneJavelin,
            BuffID.StardustMinionBleed,
            BuffID.DryadsWardDebuff,
            BuffID.Daybreak,
            BuffID.SugarRush,
            BuffID.WindPushed,
            BuffID.WitheredArmor,
            BuffID.WitheredWeapon,
            BuffID.OgreSpit,
            BuffID.NoBuilding
        };
    }
}
