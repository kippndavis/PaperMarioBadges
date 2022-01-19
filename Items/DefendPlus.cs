using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class DefendPlus : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Defend Plus");
			Tooltip.SetDefault("Increases defense by 5\nReduces damage taken by 5%");
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
            mPlayer.defendPlusItem = true;
            player.statDefense += 5;
        }
	}
}