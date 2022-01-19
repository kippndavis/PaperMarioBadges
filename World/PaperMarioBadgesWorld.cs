using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using PaperMarioBadges.NPCs;
using PaperMarioBadges.Items;

namespace PaperMarioBadges
{
	public class PaperMarioBadgesWorld : ModWorld
	{

        public override void Initialize()
        {
            /*
            var items = new List<Item>();
            Item item = new Item();
            item.SetDefaults(2);
            items.Add(item);
            shopItems = items;
            */

            Charlieton.spawnAt = double.MaxValue;
        }

        /*
        public override TagCompound Save()
        {
            return new TagCompound
            {
                ["traveler"] = Charlieton.Save()
            };
        }
        */

            /*
        public override void Load(TagCompound tag)
        {
            Charlieton.Load(tag.GetCompound("traveler"));
        }
        */

        public override void PreUpdate()
        {
            Charlieton.UpdateTravelingMerchant();
        }
	}
}