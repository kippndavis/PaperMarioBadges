using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
    public class FlowerFinder : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flower Finder");
            Tooltip.SetDefault("Upon dealing damage, a star may drop");
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
            mPlayer.flowerFinderItem = true;
        }
    }
}