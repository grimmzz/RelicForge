using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class Revolver : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 7; // Base damage\
            Item.scale = 0.60f;
            Item.DamageType = DamageClass.Ranged; // Ranged weapon
            Item.width = 64; // Hitbox width
            Item.height = 36; // Hitbox height
            Item.useTime = 40; // Use time (lower is faster)
            Item.useAnimation = 40; // Use animation duration
            Item.useStyle = ItemUseStyleID.Shoot; // Shooting style
            Item.noMelee = true; // Gun does not deal melee damage
            Item.knockBack = 2; // Knockback strength
            Item.value = Item.buyPrice(gold: 1); // Purchase value (1 gold)
            Item.rare = ItemRarityID.Blue; // Item rarity
            Item.UseSound = SoundID.Item11; // Gunfire sound
            Item.autoReuse = false; // Automatic firing
            Item.shoot = ProjectileID.Bullet; // Default projectile type
            Item.shootSpeed = 6f; // Projectile speed
            Item.useAmmo = AmmoID.Bullet; // Uses bullets as ammo
            Item.crit = 3;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6f, 1f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Terraria.ID.ItemID.IronBar, 12);  // 12 Iron Bars
            recipe.AddIngredient(Terraria.ID.ItemID.Chain, 3);     // 3 Chains
            recipe.AddIngredient(Terraria.ID.ItemID.Wood, 20);     // 20 Wood
            recipe.AddTile(Terraria.ID.TileID.Anvils);              // Crafting station: Anvil
            recipe.Register();                                      // Registers the recipe
        }
    }
}