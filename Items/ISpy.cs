using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class ISpy : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("I Spy");
			Tooltip.SetDefault("Effects active in Inventory\nRandomly grants Spelunker, Hunter, and Dangersense Effects\nAlways active with Double Pain");
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
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.iSpyItem = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.iSpyItem = true;
        }
	}
}