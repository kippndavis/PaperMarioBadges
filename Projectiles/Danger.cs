using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

using PaperMarioBadges.Items;

namespace PaperMarioBadges.Projectiles

{
    public class Danger : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.timeLeft = 131;
            projectile.light = 0.6f;
            projectile.scale = 1.5f;
            projectile.alpha = 0;
        }

        public override void AI()
        {

            projectile.rotation = 0;
            projectile.position.X = Main.player[projectile.owner].position.X - 8;
            projectile.position.Y = Main.player[projectile.owner].position.Y - 28;

            if (projectile.timeLeft >= 80)
            {
                projectile.alpha += 5;
            }

        }
    }
}