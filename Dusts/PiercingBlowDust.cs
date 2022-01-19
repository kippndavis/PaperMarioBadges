using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Dusts
{
    public class PiercingBlowDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.rotation = Main.rand.Next(360);
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 4f;
        }

        public override bool Update(Dust dust)
        {
            //dust.position += dust.velocity;
            //dust.scale *= 0.99f;
            dust.rotation = 0;
            dust.scale = dust.scale / 1.08f;
            //Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}