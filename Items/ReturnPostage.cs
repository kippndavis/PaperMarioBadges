using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class ReturnPostage : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Return Postage");
			Tooltip.SetDefault("Enemies take double the damage they deal to you\nIf that damage would kill them, you take no damage");
		}

		public override void SetDefaults() 
		{
            item.accessory = true;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 4;
        }

        public override void UpdateInventory(Player player)
        {
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 4;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.returnPostageItem = true;
        }
	}
}