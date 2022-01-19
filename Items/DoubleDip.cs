using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class DoubleDip : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Double Dip");
			Tooltip.SetDefault("Your first healing and mana potion do not trigger sickness\n5 minute cooldown");
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
            mPlayer.doubleDipItem = true;
        }
	}
}