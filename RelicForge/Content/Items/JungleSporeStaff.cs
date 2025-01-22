using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using RelicForge.Content.Projectiles;

namespace RelicForge.Content.Items
{
    public class JungleSporeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 14; // Base damage
            Item.DamageType = DamageClass.Magic; // Magic weapon
            Item.mana = 10; // Mana cost
            Item.width = 40; // Hitbox width
            Item.height = 40; // Hitbox height
            Item.useTime = 15; // Use time (lower is faster)
            Item.useAnimation = 15; // Use animation duration
            Item.useStyle = ItemUseStyleID.HoldUp; // Hold up to cast
            Item.noMelee = true; // Doesn't deal melee damage
            Item.knockBack = 3; // Knockback strength
            Item.value = Item.buyPrice(gold: 1); // Item value
            Item.rare = ItemRarityID.Orange; // Rarity color
            Item.UseSound = SoundID.Item20; // Magic sound
            Item.autoReuse = true; // Auto-cast enabled
            Item.shoot = ModContent.ProjectileType<JungleSporeProjectile>(); // Custom projectile
            Item.shootSpeed = 7f; // Speed of the projectile
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 8);
            recipe.AddIngredient(ItemID.Vine, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
