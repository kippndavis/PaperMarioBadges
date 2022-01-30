using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Projectiles

{
    public class ISpyAnim : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 120;
            projectile.light = 0.6f;
            projectile.scale = 0.35f;
            projectile.alpha = 0;
        }

        public override void AI()
        {

            projectile.rotation = 0;
            projectile.position.X = Main.player[projectile.owner].position.X - 45;
            projectile.position.Y = Main.player[projectile.owner].position.Y - 40;

            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 7;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.timeLeft <= 35)
                {
                    projectile.alpha += 90; // Fade out
                }
                if (projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
            

        }
    }
}