using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class CrimsonMusket : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 42; // Base damage\
            Item.scale = 0.85f;
            Item.DamageType = DamageClass.Ranged; // Ranged weapon
            Item.width = 40; // Hitbox width
            Item.height = 20; // Hitbox height
            Item.useTime = 50; // Use time (lower is faster)
            Item.useAnimation = 50; // Use animation duration
            Item.useStyle = ItemUseStyleID.Shoot; // Shooting style
            Item.noMelee = true; // Gun does not deal melee damage
            Item.knockBack = 6; // Knockback strength
            Item.value = Item.buyPrice(gold: 1); // Purchase value (1 gold)
            Item.rare = ItemRarityID.Blue; // Item rarity
            Item.UseSound = SoundID.Item11; // Gunfire sound
            Item.autoReuse = false; // Automatic firing
            Item.shoot = ProjectileID.Bullet; // Default projectile type
            Item.shootSpeed = 10f; // Projectile speed
            Item.useAmmo = AmmoID.Bullet; // Uses bullets as ammo
            Item.crit = 6;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, 1f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 12); // Required material
            recipe.AddTile(TileID.Anvils); // Crafting station
            recipe.Register(); // Registers the recipe
        }
    }
}