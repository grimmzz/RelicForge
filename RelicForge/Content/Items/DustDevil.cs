using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RelicForge.Content.Projectiles;

namespace RelicForge.Content.Items
{
    public class DustDevil : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 12; // Weapon damage
            Item.DamageType = DamageClass.Magic; // Magic weapon type
            Item.width = 28; // Hitbox width
            Item.height = 30; // Hitbox height
            Item.useTime = 30; // Speed of use
            Item.useAnimation = 30; // Duration of use animation
            Item.useStyle = ItemUseStyleID.HoldUp; // Hold-up style for magic weapons
            Item.noMelee = true; // Doesn't deal melee damage
            Item.knockBack = 4f; // Knockback power
            Item.value = Item.buyPrice(gold: 1); // Item cost
            Item.rare = ItemRarityID.Green; // Item rarity
            Item.UseSound = SoundID.Item117; // Razorblade Typhoon-like sound
            Item.autoReuse = true; // Allows for continuous use
            Item.shoot = ModContent.ProjectileType<DustDevilProjectile>(); // Custom projectile
            Item.shootSpeed = 5f; // Speed of the projectile
            Item.mana = 14; // Mana cost
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // First projectile
            Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(-10)), type, damage, knockback, player.whoAmI);

            // Second projectile
            Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(10)), type, damage, knockback, player.whoAmI);

            // Prevents default projectile from being shot
            return false;
        }
    }
}
