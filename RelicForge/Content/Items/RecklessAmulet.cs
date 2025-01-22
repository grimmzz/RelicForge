using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class RecklessAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true; // This makes it an accessory
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 10);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Double all damage
            player.GetDamage(DamageClass.Generic) *= 2f;

            // Halve max health
            player.statLifeMax2 /= 2;
        }
    }
}
