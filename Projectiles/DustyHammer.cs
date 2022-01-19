using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;

namespace PaperMarioBadges.Projectiles

{
    public class DustyHammer : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 600;
            projectile.aiStyle = 1;
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (target.friendly == false) return true;
            return false;
        }

        public override void AI()
        {

            projectile.scale = 0.60f;
            if (projectile.timeLeft % 4 == 0)
            {
                projectile.rotation++;
            }

            projectile.velocity.Y = projectile.velocity.Y + 0.4f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (projectile.velocity.Y > 16f) // Terminal velocity
            {
                projectile.velocity.Y = 16f;
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

    }
}