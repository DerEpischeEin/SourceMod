using System;
using System.IO.Pipes;
using System.Reflection;
using System.Security;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SourceMod.Content.Effects;

namespace SourceMod.Content.Projectiles
{
    public class SourceBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.timeLeft = 80;
            Projectile.penetrate = 100;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 0;
        }

        public override void AI()
        {
            NPC closestTarget = null;
            float closestDistance = 480f;
             for(int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if(target.CanBeChasedBy(Projectile))
                {
                    float distance = Vector2.Distance(Projectile.Center, target.Center);
                    if(distance <  closestDistance)
                    {
                        closestDistance = distance;
                        closestTarget = target;
                    }
                }
            }
            if(closestTarget !=null)
            {
                Vector2 desiredVelocity = closestTarget.Center - Projectile.Center;
                desiredVelocity.Normalize();
                float speed = 8f;
                desiredVelocity *= speed;
                float inertia = 20;
                Projectile.velocity = (Projectile.velocity * (inertia - 1f) + desiredVelocity) / inertia;
            }
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
        

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player owner = Main.player[Projectile.owner];
            int rand = Main.rand.Next(3);
            if(rand == 0)
            {
                target.AddBuff(ModContent.BuffType<CorruptionEffect>(), 600);
            }
            else if(rand == 1)
            {
                target.AddBuff(BuffID.CursedInferno, 180);
            }
            else if(rand == 2)
            {
                owner.Heal(20);
            }
        }
    }
}