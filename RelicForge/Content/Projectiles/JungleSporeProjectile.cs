using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace RelicForge.Content.Projectiles
{
    public class JungleSporeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 16; // Base hitbox width
            Projectile.height = 16; // Base hitbox height
            Projectile.aiStyle = 0; // Custom AI
            Projectile.friendly = true; // Deals damage to enemies
            Projectile.DamageType = DamageClass.Magic; // Magic damage
            Projectile.penetrate = 1; // Number of enemies it can hit
            Projectile.timeLeft = 180; // Time before it disappears
            Projectile.light = 0f; // Disable default light emission
            Projectile.damage = 5; // Base damage
            Projectile.scale = 0.75f; // Scale the projectile
        }

        public override void AI()
        {
            // Adjust hitbox size to match the scaled projectile
            Projectile.width = (int)(16 * Projectile.scale); // Scaled hitbox width
            Projectile.height = (int)(16 * Projectile.scale); // Scaled hitbox height
            Projectile.rotation += 0.1f; // Rotate the projectile slightly

            // Emit a green light
            Lighting.AddLight(Projectile.Center, 0.2f, 0.9f, 0.2f); // RGB values for green light

            // Create less dust and make it fade faster
            if (Main.rand.NextBool(3)) // Only spawn dust 1/3 of the time
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore);
                dust.velocity *= 0.5f; // Slow down dust movement
                dust.scale = 0.8f; // Smaller dust
                dust.noGravity = true; // Make dust float
                dust.fadeIn = 1.2f; // Smoothly fade out over time
            }

            // Add a subtle sine wave movement
            Projectile.velocity.Y += (float)System.Math.Sin(Projectile.ai[0]) * 0.05f;
            Projectile.ai[0] += 0.1f;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Apply Poisoned debuff to the NPC
            target.AddBuff(BuffID.Poisoned, 180); // Apply Poisoned debuff for 3 seconds

            // Play explosion sound when hitting an NPC
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center); // Explosion sound
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            // Apply Poisoned debuff to the Player
            target.AddBuff(BuffID.Poisoned, 180); // Apply Poisoned debuff for 3 seconds

            // Play explosion sound when hitting a player
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center); // Explosion sound
        }

        public override void Kill(int timeLeft)
        {
            // Poison splash damage
            int explosionRadius = 80; // Radius of the explosion
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && Vector2.Distance(npc.Center, Projectile.Center) <= explosionRadius)
                {
                    int splashDamage = Projectile.damage / 1; // Splash damage is full projectile damage
                    npc.SimpleStrikeNPC(splashDamage, 0); // Apply splash damage with no knockback
                    npc.AddBuff(BuffID.Poisoned, 300); // Apply Poisoned debuff for 5 seconds
                }
            }

            // Play explosion sound when the projectile explodes
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center); // Explosion sound

            // Reduced dust and controlled spread on destruction
            for (int i = 0; i < 10; i++) // Number of dust particles
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore);
                dust.velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f)); // Controlled random velocity
                dust.scale = 1.2f; // Slightly larger dust
                dust.noGravity = true; // Keep dust floating
            }
        }
    }
}