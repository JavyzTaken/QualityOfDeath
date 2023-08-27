using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityOfDeath.Features.AccessoryBees
{
    public class BeeAccessoryPlayer : ModPlayer
    {
        private List<ModAccessorySlot> _modAccessorySlots = new();
        private ModItem _beeAccessory;

        public override void OnEnterWorld()
        {
            base.OnEnterWorld();
            _beeAccessory = ModContent.GetInstance<BeeAccessory>();
            _modAccessorySlots.AddRange(ModContent.GetContent<ModAccessorySlot>());
        }

        public override void UpdateEquips()
        {
            base.UpdateEquips();
            foreach (ModAccessorySlot slot in _modAccessorySlots)
            {
                if (slot.FunctionalItem.type != _beeAccessory.Type || slot.IsEmpty)
                {
                    // TODO: This works. Somehow. I don't know why.
                    // Logic to create a new, unique Item of a type, with ModItem intact.
                    // Needed so the bee accessory has the proper tooltip and effect, I think.
                    Item item = _beeAccessory.Item.Clone();
                    item.CloneDefaults(_beeAccessory.Type);
                    _beeAccessory.Clone(item);
                    slot.FunctionalItem = item;
                }
            }
        }

        public override void PostUpdate()
        {
            if (Player.trashItem.type == _beeAccessory.Type && !Player.trashItem.IsAir)
            {
                _ = NPC.NewNPC(new EntitySource_Misc("BeeAccessoryTrashed"), (int)Player.position.X, (int)Player.position.Y, NPCID.Bee);
                Player.trashItem.TurnToAir();
            }
            base.PostUpdate();
        }
    }
}
