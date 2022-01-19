using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class PUpDDown : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("P-Up D-Down");
			Tooltip.SetDefault("Increases damage by 20%\nDecreases defense by 20%");
		}

		public override void SetDefaults() 
		{
            item.accessory = true;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 3;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 3;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.pUpDDownItem = true;
        }
	}
}