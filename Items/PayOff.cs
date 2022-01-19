using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class PayOff : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pay-Off");
			Tooltip.SetDefault("Effects active in Inventory\nRarely, a gold coin portal will spawn upon receiving damage\nEven rarer, a platinum coin portal will spawn instead\nOdds are increased with Double Pain");
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
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.payOffItem = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 2;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.payOffItem = true;
        }
	}
}