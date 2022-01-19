using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class PrettyLucky : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pretty Lucky");
			Tooltip.SetDefault("Sometimes makes enemies fail to attack you\n1/12 proc rate");
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
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.prettyLuckyItem = true;
        }
	}
}