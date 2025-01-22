using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RelicForge.Content.Projectiles
{
    public class TumbleWeedProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Setting yoyo related properties
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 12f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 250f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Apply Confused debuff to the NPC (you can change this to Poison if needed)
            target.AddBuff(BuffID.Confused, 90); // Apply Confused debuff for 3 seconds
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            // Apply Confused debuff to the Player
            target.AddBuff(BuffID.Confused, 90); // Apply Confused debuff for 3 seconds
        }

        public override void SetDefaults()
        {
            Projectile.width = 16; // The width of the projectile's hitbox
            Projectile.height = 16; // The height of the projectile's hitbox
            Projectile.aiStyle = ProjAIStyleID.Yoyo; // Yoyo aiStyle for handling projectile behavior
            Projectile.friendly = true; // The projectile is friendly, so it can deal damage to enemies
            Projectile.DamageType = DamageClass.MeleeNoSpeed; // Projectile uses melee but doesn't scale with attack speed
            Projectile.penetrate = -1; // Infinite penetration (the projectile won't disappear after hitting one enemy)
        }

        public override void AI()
        {
            // Removed the dust spawning logic
        }
    }
}
