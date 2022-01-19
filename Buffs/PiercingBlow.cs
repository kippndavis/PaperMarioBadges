using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;
using PaperMarioBadges.Dusts;

namespace PaperMarioBadges.Buffs
{
	public class PiercingBlow : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Piercing Blow");
            Description.SetDefault("20 defense is ignored and taking increased knockback");
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.Next(8) == 0)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), 32, 32, ModContent.DustType<PiercingBlowDust>(), 0, 0, 100, Color.White, 1.7f);
            }
        }
    }
}