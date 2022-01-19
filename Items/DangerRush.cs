using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class DangerRush : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Danger Rush");
            Tooltip.SetDefault("Wearer deals 33% more damage when below 50% HP\nDoesn't stack with Mega Rush");
        }

		public override void SetDefaults() 
		{
            item.accessory = true;
            item.value = item.value = Item.sellPrice(0, 4, 0, 0);
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
            mPlayer.dangerRushItem = true;
        }
	}
}