using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

namespace QualityOfDeath.Features.AccessoryBees
{
    public class BeeAccessory : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.accessory = true;
            Item.width = 16;
            Item.height = 16;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegen = -4;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            _ = NPC.NewNPC(new EntitySource_Misc("BeeAccessoryThrown"), (int)Item.position.X, (int)Item.position.Y, NPCID.Bee);
            Item.TurnToAir();
            base.Update(ref gravity, ref maxFallSpeed);
        }
    }
}
