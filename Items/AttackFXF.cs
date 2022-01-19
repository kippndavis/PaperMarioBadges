using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class AttackFXF : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Attack FX F");
            Tooltip.SetDefault("Effects active in Inventory\nChanges the sound of your attacks\nFavorite this to disable this effect");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 0;
        }

        public override void UpdateInventory(Player player)
        {
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (!item.favorited)
            {
                mPlayer.attackFXFItem = true;
            }
        }
    }
}