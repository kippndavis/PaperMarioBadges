using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

using PaperMarioBadges.Projectiles;

namespace PaperMarioBadges.Items
{
	public class AngersPower : ModItem
	{

        public bool playEffect = false;


        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Anger's Power");
			Tooltip.SetDefault("Effects active in Inventory\nGrants the Rage and Wrath effects\nRandomly afflicts Confusion, Silenced or Cursed");
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

            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.angersWrathItem = true;
            if (playEffect == false)
            {
                playEffect = true;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/MarioAnger"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<AngersWrathAnim>(), 0, 0f);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            item.rare = 2;

            modPlayer mPlayer = (modPlayer)(player.GetModPlayer(mod, "modPlayer"));
            mPlayer.angersWrathItem = true;
            if (playEffect == false)
            {
                playEffect = true;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/MarioAnger"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<AngersWrathAnim>(), 0, 0f);
            }
        }
	}
}