using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Projectiles
{
    public class JungleSpearProjectile : ModProjectile
    {
        // Define the range of the Spear Projectile. These are overrideable properties, in case you'll want to make a class inheriting from this one.
        protected virtual float HoldoutRangeMin => 24f;
        protected virtual float HoldoutRangeMax => 110f;

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            // Clone the defaults for the spear and customize as needed.
            Projectile.width = 40;  // Width of the projectile (spear's width)
            Projectile.height = 40; // Height of the projectile (spear's height)
            Projectile.aiStyle = 19; // This makes the projectile behave like a spear
            Projectile.friendly = true; // Make the projectile friendly
            Projectile.penetrate = -1; // Allow unlimited hits before disappearing
            Projectile.tileCollide = false; // Disable tile collision, as it is a held projectile
            Projectile.scale = 1.25f; // Scale of the spear
            Projectile.hide = false; // Ensures the spear is visible
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner]; // Player reference for easier access
            int duration = player.itemAnimationMax; // The duration the projectile will exist in frames

            player.heldProj = Projectile.whoAmI; // Update the player's held projectile ID

            // Reset projectile time left if necessary
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            // Normalize the velocity to determine the direction of the projectile
            if (Projectile.velocity != Vector2.Zero) // Check if velocity is non-zero
            {
                Projectile.velocity = Vector2.Normalize(Projectile.velocity);
            }

            float halfDuration = duration * 0.5f;
            float progress;

            // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }

            // Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            // Apply proper rotation to the sprite.
            if (Projectile.spriteDirection == -1)
            {
                // If sprite is facing left, rotate 45 degrees
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                // If sprite is facing right, rotate 135 degrees
                Projectile.rotation += MathHelper.ToRadians(135f);
            }

            return false; // Prevent the default AI from running
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Apply Poisoned debuff to the NPC
            target.AddBuff(BuffID.Poisoned, 180); // Apply Poisoned debuff for 3 seconds
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            // Apply Poisoned debuff to the Player
            target.AddBuff(BuffID.Poisoned, 180); // Apply Poisoned debuff for 3 seconds
        }
    }
}