using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

using PaperMarioBadges.Items;

namespace PaperMarioBadges.Projectiles

{
    public class NoDamageAnim : ModProjectile
    {

        public bool getDirection = true;
        public int direction = 0;

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 12; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 50;
            projectile.light = 1f;
            projectile.alpha = 0;
        }

        public override void AI()
        {

            if (getDirection) { // Make the projectile fly in the way the player is facing when hit
                getDirection = false; 
                direction = Main.player[projectile.owner].direction; 
            }
            projectile.rotation = 0;
            projectile.scale = 0.6f;
            projectile.position.X += (4 * direction);
            projectile.position.Y -= 2;

            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 3;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.timeLeft <= 35)
                {
                    projectile.alpha += 30; // Fade out
                }
                if (projectile.frame >= 12)
                {
                    projectile.frame = 0;
                }
            }
            

        }
    }
}