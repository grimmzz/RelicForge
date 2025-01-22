using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Projectiles
{
    public class DustDevilProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3; // Set the number of animation frames
        }

        public override void SetDefaults()
        {
            Projectile.width = 62; // Projectile width
            Projectile.height = 62; // Projectile height
            Projectile.friendly = true; // Can hit enemies
            Projectile.hostile = false; // Doesn't hurt players
            Projectile.DamageType = DamageClass.Magic; // Properly set the damage type to Magic
            Projectile.penetrate = 2; // Number of enemies it can hit before disappearing
            Projectile.timeLeft = 300; // Lifetime of the projectile in frames
            Projectile.light = 0.1f; // Light emitted
            Projectile.tileCollide = false; // Passes through tiles
            Projectile.scale = 1f;
        }

        public override void AI()
        {
            // Reduce projectile damage to 30% of its original value
            if (Projectile.localAI[0] == 0) // Ensure this runs only once
            {
                Projectile.damage = (int)(Projectile.damage * 0.9f); // Set damage to 80% of its original value
                Projectile.localAI[0] = 1; // Mark as initialized
            }

            // Create a spiraling motion
            Projectile.rotation += 0.6f; // Rotation for visual effect
            float maxDetectRadius = 400f; // Maximum range to detect targets
            float homingSpeed = 30f; // Speed at which it homes in on targets

            // Find the closest NPC target
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC != null)
            {
                // Move toward the target
                Vector2 direction = closestNPC.Center - Projectile.Center;
                direction.Normalize();
                direction *= homingSpeed;
                Projectile.velocity = (Projectile.velocity * 30f + direction) / 31f;
            }

            // Create a visual dust effect
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sandstorm, Scale: 1.50f);
            }
        }

        public override void Kill(int timeLeft)
        {
            // Emit dust and light particles when the projectile disappears
            for (int i = 0; i < 20; i++) // Dust effect
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sandstorm,
                             Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f), 100, default, 1.5f);
            }

            // Emit light particles falling downwards
            for (int i = 0; i < 10; i++) // Light particles
            {
                Dust lightDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare,
                             Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-2f, -1f), 100, default, 2f);
                lightDust.noGravity = true; // Ensures the dust falls straight down
                lightDust.fadeIn = 1f; // Makes the light fade out over time
                lightDust.velocity.Y += 0.1f; // Simulates falling with gravity effect
                lightDust.scale = 1.5f; // Adjust size of the light particles
            }
        }

        private NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;
            float closestDistance = maxDetectDistance;

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this) && !npc.friendly)
                {
                    float distance = Vector2.Distance(Projectile.Center, npc.Center);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
            }

            return closestNPC;
        }
    }
}
