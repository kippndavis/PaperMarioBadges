using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class HeartFinder : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Heart Finder");
			Tooltip.SetDefault("Upon dealing damage, a heart may drop");
		}

		public override void SetDefaults() 
		{
            item.accessory = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 2;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 2;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.heartFinderItem = true;
        }
	}
}