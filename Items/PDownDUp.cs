using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class PDownDUp : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("P-Down D-Up");
			Tooltip.SetDefault("Increases defense by 20%\nDecreases damage by 20%");
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
            mPlayer.pDownDUpItem = true;
        }
	}
}