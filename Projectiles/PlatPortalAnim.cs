using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;

using PaperMarioBadges.Dusts;

namespace PaperMarioBadges.Projectiles

{
    public class PlatPortalAnim : ModProjectile
    {

        int rnd = Main.rand.Next(3);

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 200;
            projectile.alpha = 200;
            projectile.light = 0.5f;
        }

        public override void AI()
        {

            projectile.rotation = 0;

            if (projectile.timeLeft > 150 && projectile.alpha > 70)
            {
                projectile.alpha -= 3;
            } else if (projectile.timeLeft < 12)
            {
                projectile.scale = projectile.scale / 1.01f;
                projectile.alpha += 3;
            }

            // Spawn 3, 6, or 9 coins
            if (rnd == 0)
            {
                if (projectile.timeLeft % 60 == 0)
                {
                    Item.NewItem(projectile.getRect(), ItemID.PlatinumCoin);
                }
            } else if (rnd == 1)
            {
                if (projectile.timeLeft % 30 == 0)
                {
                    Item.NewItem(projectile.getRect(), ItemID.PlatinumCoin);
                }
            } else
            {
                if (projectile.timeLeft % 21 == 0)
                {
                    Item.NewItem(projectile.getRect(), ItemID.PlatinumCoin);
                }
            }

            // Should update dust to only appear at portal edges
            if (Main.rand.Next(3) == 0) {
                int dust = Dust.NewDust(projectile.position - new Vector2(2f, 2f), 32, 32, ModContent.DustType<Sparkle>(), 0, 0, 100, Color.White, 1.7f);
            }

            if (projectile.timeLeft % 10 == 0)
            {
                Item item = new Item();
                item.SetDefaults();
            }

            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 4;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            

        }
    }
}