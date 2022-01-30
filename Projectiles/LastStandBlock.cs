using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Projectiles

{
    public class LastStandBlock : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.timeLeft = 180;
            projectile.light = 0.6f;
            projectile.scale = 0.8f;
            projectile.alpha = 0;
        }

        public override void AI()
        {

            projectile.rotation = 0;
            projectile.position.X = Main.player[projectile.owner].position.X - 66;
            projectile.position.Y = Main.player[projectile.owner].position.Y - 75;

            if (projectile.timeLeft >= 105)
            {
                projectile.alpha += 5;
            }

        }
    }
}