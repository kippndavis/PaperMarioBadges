using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class LastStand : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Last Stand");
			Tooltip.SetDefault("Wearer takes 25% reduced damage when below 50% HP\nIf lethal damage would be taken above 50% HP, HP is reduced to 1 instead");
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
            mPlayer.lastStandItem = true;
        }
	}
}