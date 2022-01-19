using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class SlowGo : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slow Go");
			Tooltip.SetDefault("Effects active in Inventory\nGrounded movement speed reduced by 75%\nFlight time greatly reduced\nEffects are inversed with Double Pain");
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
            mPlayer.slowGoItem = true;

            if (mPlayer.slowGoBonus)
            {
                player.moveSpeed = (float)(player.moveSpeed * 1.75);
                player.accRunSpeed = (float)(player.accRunSpeed * 1.75);
            }
            else
            {
                player.wingTime = 0;
                player.moveSpeed = (float)(player.moveSpeed * 0.25);
                player.accRunSpeed = (float)(player.accRunSpeed * 0.25);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.rare = 1;
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.slowGoItem = true;

            if (mPlayer.slowGoBonus)
            {
                player.moveSpeed = (float)(player.moveSpeed * 1.75);
                player.accRunSpeed = (float)(player.accRunSpeed * 1.75);
            }
            else
            {
                player.wingTime = 0;
                player.moveSpeed = (float)(player.moveSpeed * 0.25);
                player.accRunSpeed = (float)(player.accRunSpeed * 0.25);
            }
        }
	}
}