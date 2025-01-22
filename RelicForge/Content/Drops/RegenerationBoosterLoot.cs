using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace RelicForge.Content.Items
{
    public class RegenerationBoosterLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot loot)
        {
            // Check if the item is an Iron Crate
            if (item.type == ItemID.IronCrate)
            {
                // Add Regeneration Booster to the loot pool of Iron Crates with a 33% chance
                loot.Add(ItemDropRule.Common(ModContent.ItemType<RegenerationBooster>(), 4, 0, 1)); // 33% chance (weight 3 out of 9)
            }
        }
    }
}
