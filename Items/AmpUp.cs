using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class AmpUp : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Amp Up");
			Tooltip.SetDefault("Effects active in Inventory\nDoubles enemy spawn rate\nFavorite this to enable this effect");
		}

		public override void SetDefaults() 
		{
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (item.favorited)
            {
                mPlayer.ampUpItem = true;
            }
        }
    }
}