using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class ChillOut : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chill Out");
			Tooltip.SetDefault("Effects active in Inventory\nHalves enemy spawn rate\nFavorite this to disable this effect");
        }

		public override void SetDefaults() 
		{
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 1;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (!item.favorited)
            {
                mPlayer.chillOutItem = true;
            }
        }
    }
}