using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class FPPlus : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("FP Plus");
			Tooltip.SetDefault("Increases maximum mana by 50");
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
            player.statManaMax2 += 50;
        }
	}
}