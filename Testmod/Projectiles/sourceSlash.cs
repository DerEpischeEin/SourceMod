using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Testmod.Projectiles 
{
    public class sourceSlash : ModProjectile
    {
        public static readonly SoundStyle errSlash = new("Testmod/Sounds/errSound") { PitchVariance = 0.3f };

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 direction = new Vector2((float)Math.Cos(Projectile.rotation), (float)Math.Sin(Projectile.rotation));
            Vector2 start = Projectile.Center - direction * (Projectile.height / 2f);
            Vector2 end = Projectile.Center + direction * (Projectile.height / 2f);

            Vector2 targetCenter = new Vector2(targetHitbox.X + targetHitbox.Width / 2f, targetHitbox.Y + targetHitbox.Height / 2f);

            Vector2 segment = end - start;
            float t = MathHelper.Clamp(Vector2.Dot(targetCenter - start, segment) / segment.LengthSquared(), 0f, 1f);
            Vector2 closestPoint = start + segment * t;

            float hitReach = (Projectile.width / 2f) + (Math.Max(targetHitbox.Width, targetHitbox.Height) / 2f);
            return Vector2.Distance(closestPoint, targetCenter) < hitReach;
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 64;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 600;
            AIType = ProjectileID.Bullet;
        }
        
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(errSlash, Projectile.position);
        }
    }
}