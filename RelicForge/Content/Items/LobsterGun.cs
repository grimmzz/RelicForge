using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using RelicForge.Content.Projectiles;
using Terraria.GameContent.ItemDropRules;

namespace RelicForge.Content.Items
{
    public class LobsterGun : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 12; // Base damage
            Item.scale = 1f;
            Item.DamageType = DamageClass.Ranged; // Ranged weapon
            Item.width = 40; // Hitbox width
            Item.height = 20; // Hitbox height
            Item.useTime = 25; // Use time (lower is faster)
            Item.useAnimation = 25; // Use animation duration
            Item.useStyle = ItemUseStyleID.Shoot; // Shooting style
            Item.noMelee = true; // Gun does not deal melee damage
            Item.knockBack = 2; // Knockback strength
            Item.value = Item.buyPrice(gold: 1); // Purchase value (1 gold)
            Item.rare = ItemRarityID.Blue; // Item rarity
            Item.UseSound = SoundID.Item11; // Gunfire sound
            Item.autoReuse = false; // Automatic firing
            Item.shoot = ModContent.ProjectileType<LobsterShot>(); // Custom projectile
            Item.shootSpeed = 2f; // Projectile speed
            Item.useAmmo = AmmoID.Bullet; // Uses bullets as ammo
            Item.crit = 2;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            // Prevent ammo from being consumed if the projectile is your custom projectile.
            return base.CanConsumeAmmo(ammo, player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Override the projectile type to always shoot LobsterShot
            type = ModContent.ProjectileType<LobsterShot>();

            // Spawn the custom projectile
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            // Return false to prevent the default projectile from being shot
            return false;

            Vector2 muzzleOffset = new Vector2(40 * player.direction, 0f); // Change 40 to adjust the distance from the player
            position = player.MountedCenter + muzzleOffset; // Set spawn position to player's mounted center + muzzle offset

            // Get the mouse position and calculate the direction toward the mouse
            Vector2 mousePosition = Main.MouseWorld;
            Vector2 directionToMouse = mousePosition - position; // Direction from the gun to the mouse
            directionToMouse.Normalize(); // Normalize to unit length for consistent velocity

            // Adjust projectile velocity
            velocity = directionToMouse * 6f; // Adjust 6f for projectile speed

            // Spawn the custom LobsterShot projectile
            type = ModContent.ProjectileType<LobsterShot>(); // Ensure you're using the correct custom projectile type
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            // Return false to prevent the default projectile from firing
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(1f, 1f);
        }
    }
}

