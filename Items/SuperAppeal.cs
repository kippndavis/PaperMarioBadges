using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class SuperAppeal : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Super Appeal");
			Tooltip.SetDefault("Effects active in Inventory\nWearer gets a morale boost on enemy kill\nFavorite this to enable this effect\n\"Finally, some recognition!\"");
		}

		public override void SetDefaults() 
		{
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 1;
        }

        public override void UpdateInventory(Player player)
        {
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (item.favorited)
            {
                mPlayer.superAppealItem = true;
            }
        }
	}
}