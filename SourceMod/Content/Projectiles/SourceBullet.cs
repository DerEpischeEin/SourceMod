using System;
using System.IO.Pipes;
using System.Reflection;
using System.Security;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SourceMod.Content.Projectiles
{
    public class SourceBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Source Bullet";
            projectile.width = 8;
            projectile.height = 8;
            projectile.timeLeft = 80;
            projectile.penetrate = 100;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.ranged = true;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
             for(int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if(target.hostile)
                {
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    if(distance < 480f && !target.friendly && target.active)
                    {
                        distance = 3f / distance;
                        shootToX *= distance * 7;
                        shootToY *= distance * 8;
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(3);
            if(rand == 0)
            {
                target.AddBuff(BuffID.CorruptionEffect, 600);
            }
            if(rand == 1)
            {
                target.AddBuff(39,180);
            }
            if(rand == 0)
            {
                owner.statLife += 20;
                owner.HealEffect(20, true);
            }
        }
    }
}