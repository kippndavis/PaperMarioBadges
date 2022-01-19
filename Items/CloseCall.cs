using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class CloseCall : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Close Call");
			Tooltip.SetDefault("Sometimes makes enemies fail to attack you\nActive when below 50% HP\n1/9 proc rate");
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
            mPlayer.closeCallItem = true;
        }
	}
}