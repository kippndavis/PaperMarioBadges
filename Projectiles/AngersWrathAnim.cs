using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Projectiles

{
    public class AngersWrathAnim : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 10; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 200;
            projectile.alpha = 255;
            projectile.light = 0.5f;
        }

        public override void AI()
        {

            projectile.rotation = 0;
            projectile.position.X = Main.player[Main.myPlayer].position.X - 30;
            projectile.position.Y = Main.player[Main.myPlayer].position.Y - 105;

            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 4;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame == 10)
                {
                    projectile.frame = 0;
                }
            }

            if (projectile.timeLeft < 50)
            {
                projectile.alpha += 10;
            } else if (projectile.timeLeft > 150)
            {
                projectile.alpha -= 5;
            }
            

        }
    }
}