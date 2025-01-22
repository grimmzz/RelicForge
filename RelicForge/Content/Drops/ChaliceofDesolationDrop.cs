using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace RelicForge.Content.Items
{
    public class ChaliceofDesolationDrop : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            // Check if the item is Plantera's Boss Bag
            if (item.type == ItemID.PlanteraBossBag)
            {
                // Add Chalice of Desolation with 100% drop chance to the Boss Bag loot
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaliceOfDesolation>(), 2, 0, 1)); // 100% drop chance
            }
        }
    }
}
