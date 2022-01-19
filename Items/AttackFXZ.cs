using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace PaperMarioBadges.Items
{
	public class AttackFXZ : ModItem
	{

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Attack FX Z");
			Tooltip.SetDefault("Effects active in Inventory\nChanges the sound of your attacks\nFavorite this to enable the effect\n\"Oh, the noise... oh, the noise, noise, noise, NOISE!\"");
		}

		public override void SetDefaults() 
		{
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 0;
        }

        public override void UpdateInventory(Player player)
        {
            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            if (item.favorited)
            {
                mPlayer.attackFXAItem = true;
                mPlayer.attackFXBItem = true;
                mPlayer.attackFXCItem = true;
                mPlayer.attackFXDItem = true;
                mPlayer.attackFXEItem = true;
                mPlayer.attackFXFItem = true;
            }
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AttackFXA>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AttackFXB>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AttackFXC>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AttackFXD>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AttackFXE>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AttackFXF>(), 1);
            recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}