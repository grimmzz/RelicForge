using Terraria;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class ReinforcedShield : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 28; // Width of the item
            Item.height = 32; // Height of the item
            Item.accessory = true; // Make it an accessory
            Item.rare = Terraria.ID.ItemRarityID.Green; // Set rarity
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Increase the player's defense by 6
            player.statDefense += 3;

            // Reduce damage taken by 15%
            player.endurance += 0.5f; // 15% damage reduction
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(Terraria.ID.ItemID.IronBar, 12)  // 12 Iron Bars
                .AddIngredient(Terraria.ID.ItemID.Wood, 20)     // 20 Wood
                .AddIngredient(Terraria.ID.ItemID.Chain, 3)     // 3 Chains
                .AddTile(Terraria.ID.TileID.Anvils)              // Crafting station: Anvil
                .Register();
        }
    }
}
