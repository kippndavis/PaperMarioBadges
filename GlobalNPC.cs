using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

using PaperMarioBadges.Items;


namespace PaperMarioBadges
{
    public class globalNPC : GlobalNPC
    {

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (mPlayer.ampUpItem && !mPlayer.chillOutItem)
            {
                spawnRate = (int)(spawnRate / 2);
                maxSpawns = (int)(maxSpawns * 1.5);
            }

            if (mPlayer.chillOutItem && !mPlayer.ampUpItem)
            {
                spawnRate = (int)(spawnRate * 2);
                maxSpawns = (int)(maxSpawns / 1.5);
            }

        }

    }
}

            
        