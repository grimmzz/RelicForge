using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RelicForge.Content.Drops
{
    public class TumbleWeedDrop : GlobalNPC
    {
        // This method will be called when an NPC is killed
        public override void OnKill(NPC npc)
        {
            // Check if the NPC is an Angry Tumbler (ID = 174)
            if (npc.type == 546) // Corrected NPC ID for Angry Tumbler
            {
                // Add the Tumble Weed drop with 66% chance (1/3 drop chance)
                if (Main.rand.Next(3) == 0) // 66% chance to drop the item
                {
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<Content.Items.TumbleWeed>(), 1); // Drop Tumble Weed
                }
            }
        }
    }
}