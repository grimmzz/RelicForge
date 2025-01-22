using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace RelicForge.Content.Projectiles
{
    public class LobsterShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 24; // Width of the projectile
            Projectile.height = 8; // Height of the projectile
            Projectile.aiStyle = 0; // No predefined AI
            Projectile.friendly = true; // Can hit enemies
            Projectile.DamageType = DamageClass.Ranged; // Projectile type
            Projectile.penetrate = 1; // Hits before disappearing
            Projectile.timeLeft = 300; // Time before disappearing (in frames)
            Projectile.tileCollide = true; // Collides with tiles
            Projectile.knockBack = 0f; // Set knockback to 0 to avoid stunning enemies
            Projectile.scale = 0.75f;
            Projectile.damage = 1; // This is the base integer value for damage (can be modified)
        }

        public override void AI()
        {
            // Set the rotation of the projectile to match its velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Add a white light source around the projectile
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f); // White glow (RGB = 1f, 1f, 1f)

            // Create bubble-themed dust trail behind the projectile
            if (Main.rand.NextBool(2)) // 50% chance to create dust per frame
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Water,
                                                Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
                dust.scale = 1.5f; // Scale the dust to make it larger
                dust.fadeIn = 1.2f; // Make the bubble fade in a little slower
                dust.noGravity = true; // No gravity, so it floats up like a bubble
            }
        }

        public override void Kill(int timeLeft)
        {
            Explode(); // Trigger explosion on projectile death
        }

        private void Explode()
        {
            // Create explosion dust effect (bubbles for explosion)
            for (int i = 0; i < 30; i++)
            {
                // New bubble dust for the explosion effect
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Water,
                                                Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                dust.scale = 2f; // Increase the size of the dust for a bigger explosion effect
                dust.fadeIn = 1.5f; // Add a fade-in effect to the dust
                dust.noGravity = true; // Make the dust float upwards like a bubble
            }

            // Play explosion sound
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            // Damage nearby NPCs
            int explosionRadius = 100; // Radius in pixels
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.Distance(Projectile.Center) <= explosionRadius)
                {
                    // Calculate damage as 0.50 (multiply by 0.5f to simulate fractional damage)
                    float damageMultiplier = 0.25f;
                    int finalDamage = (int)(Projectile.damage * damageMultiplier); // Multiply by 0.5 to simulate fractional damage

                    // Create the HitInfo object
                    NPC.HitInfo hitInfo = new NPC.HitInfo
                    {
                        Damage = finalDamage,
                        Knockback = 0f, // Set knockback to 0 to prevent any knockback on hit
                        HitDirection = Projectile.Center.X > npc.Center.X ? -1 : 1, // Determine direction
                        Crit = Main.rand.Next(100) < Projectile.CritChance // Determine critical hit
                    };

                    // Apply the damage (no knockback)
                    npc.StrikeNPC(hitInfo);
                }
            }
        }
    }
}