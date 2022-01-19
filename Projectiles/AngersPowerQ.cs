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
            if (modPlayer.direction == 1)
            {
                projectile.position.X = Main.player[Main.myPlayer].position.X - 31;
            } else
            {
                projectile.position.X = Main.player[Main.myPlayer].position.X - 35;
                
            }
            projectile.position.Y = Main.player[Main.myPlayer].position.Y - 40;

            if (projectile.timeLeft >= 80)
            {
                projectile.alpha += 7;
            }


        }
    }
}