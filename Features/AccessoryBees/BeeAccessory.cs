using Terraria;
using Terraria.ModLoader;

namespace QualityOfDeath
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

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            player.lifeRegen -= 4;
        }
    }
}
