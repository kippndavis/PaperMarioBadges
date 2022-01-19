using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class TriumphantTrumpet : ModItem
	{

        public int ticks = 0;


        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Triumphant Trumpet");
			Tooltip.SetDefault("For all your celebratory needs!");
		}

		public override void SetDefaults() 
		{
            item.width = 29;
            item.height = 29;
            item.consumable = true;
            item.useTime = 100;
            item.useAnimation = 100;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTurn = true;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 1;
            item.maxStack = 999;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {

            if (ticks == 0) Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BadgeGet"));
            ticks++;
            if (ticks <= 100) ticks = 0;
            return true;
        }
	}
}