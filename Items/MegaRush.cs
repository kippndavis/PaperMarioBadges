using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

using PaperMarioBadges.Items;

namespace PaperMarioBadges.Items
{
	public class MegaRush : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mega Rush");
			Tooltip.SetDefault("Wearer deals 50% more damage when below 25% HP\nAlso gets guaranteed critical strikes with Double Pain");
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
            mPlayer.megaRushItem = true;
        }
	}
}