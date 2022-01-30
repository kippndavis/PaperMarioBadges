using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

using PaperMarioBadges.Items;

namespace PaperMarioBadges.Projectiles

{
    public class AngersPowerQ : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.timeLeft = 120;
            projectile.light = 0.6f;
            projectile.scale = 0.3f;
            projectile.alpha = 0;
        }

        public override void AI()
        {

            projectile.rotation = 0;
            if (Main.player[projectile.owner].direction == 1)
            {
                projectile.position.X = Main.player[projectile.owner].position.X - 31;
            } else
            {
                projectile.position.X = Main.player[projectile.owner].position.X - 35;

            }

            projectile.position.Y = Main.player[projectile.owner].position.Y - 40;

            if (projectile.timeLeft >= 80)
            {
                projectile.alpha += 7;
            }


        }
    }
}