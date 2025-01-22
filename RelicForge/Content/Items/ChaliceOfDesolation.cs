using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class ChaliceOfDesolation : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true; // This makes it an accessory
            Item.rare = ItemRarityID.Yellow; // Yellow rarity for Expert Mode drops
            Item.value = Item.buyPrice(gold: 10); // Value of the item
            Item.expert = true; // Makes the item have a rainbow name
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Quadruple all damage
            player.GetDamage(DamageClass.Generic) *= 4f;

            // Reduce max health to 25%
            player.statLifeMax2 /= 4;
        }
    }
}
