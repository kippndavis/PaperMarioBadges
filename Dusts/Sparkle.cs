using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Dusts
{
    public class Sparkle : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.rotation = Main.rand.Next(360);
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            //dust.position += dust.velocity;
            //dust.scale *= 0.99f;
            dust.scale = dust.scale / 1.05f;


            float light = 1f;
            Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}