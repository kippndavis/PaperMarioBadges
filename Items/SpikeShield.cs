using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class SpikeShield : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Spike Shield");
			Tooltip.SetDefault("Effects active in Inventory\nWearer takes greatly reduced damage from Boulders and Dart Traps");
		}

		public override void SetDefaults() 
		{
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.spikeShieldItem = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.spikeShieldItem = true;
        }
	}
}