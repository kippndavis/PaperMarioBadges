using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.Localization;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

using PaperMarioBadges.Items;
using PaperMarioBadges.Projectiles;

namespace PaperMarioBadges.NPCs
{

    [AutoloadHead]

    public class Charlieton : ModNPC
    {

        public static int itemCount = 0;
        public int frameCount = 0;
        public int rangedAttack = 0;

        public static int spawnChance = 5;
        public const double despawnAt = 54000.0;
        public static double spawnAt = double.MaxValue;
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        public static void UpdateTravelingMerchant()
        {

            NPC traveler = FindNPC(ModContent.NPCType<Charlieton>()); // Find an Explorer if there's one spawned in the world
            if (traveler != null && (!Main.dayTime || Main.time >= despawnAt) && !IsNpcOnscreen(traveler.Center)) // If it's past the despawn time and the NPC isn't onscreen
            {
                // Here we despawn the NPC and send a message stating that the NPC has despawned
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Charlieton the Badge Merchant has departed!", 50, 125, 255);
                else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Charlieton the Badge Merchant has departed!"), new Color(50, 125, 255));
                traveler.active = false;
                traveler.netSkip = -1;
                traveler.life = 0;
                traveler = null;
            }

            // Main.time is set to 0 each morning
            if (Main.dayTime && Main.time == 0)
            {

                // NPC won't spawn today if it stayed all night
                if (traveler == null && Main.rand.Next(spawnChance) == 0)
                {
                  // Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
                  spawnAt = GetRandomSpawnTime(27000, 46800); // Time range: 12 PM to 5:30 PM
                  //if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Debug: Badge Merchant spawns at: " + spawnAt, 50, 125, 255);
                }
                else
                {
                    spawnAt = double.MaxValue; // No spawn
                    spawnChance--; // Increase likelihood of spawn
                }
            }

            // Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
            if (traveler == null && CanSpawnNow())
            {
                spawnChance = 5; // Reset spawn chance
                int newTraveler = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<Charlieton>(), 1); // Spawning at the world spawn
                traveler = Main.npc[newTraveler];
                traveler.homeless = true;
                traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
                traveler.netUpdate = true;

                // Prevents the traveler from spawning again the same day
                spawnAt = double.MaxValue;

                // Announce that the traveler has spawned in
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", "Charlieton the Badge Merchant"), 50, 125, 255);
                else NetMessage.BroadcastChatMessage(NetworkText.FromKey("Charlieton the Badge Merchant has arrived!", traveler.GetFullNetName()), new Color(50, 125, 255));

            }
        }

        private static bool CanSpawnNow()
        {
            // can't spawn if any events are running
            if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
                return false;

            // can't spawn if the sundial is active
            if (Main.fastForwardTime)
                return false;

            // can spawn if daytime, and between the spawn and despawn times
            return Main.dayTime && Main.time >= spawnAt && Main.time < despawnAt;
        }

        private static bool IsNpcOnscreen(Vector2 center)
        {
            int w = NPC.sWidth + NPC.safeRangeX * 2;
            int h = NPC.sHeight + NPC.safeRangeY * 2;
            Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
            foreach (Player player in Main.player)
            {
                // If any player is close enough to the traveling merchant, it will prevent the npc from despawning
                if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
            }
            return false;
        }

        public static double GetRandomSpawnTime(double minTime, double maxTime)
        {
            // A simple formula to get a random time between two chosen times
            return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
        }

        /* This solution from ExampleMod is nice, but does not seem to work in Multiplayer, specifically with non-hosts trying to access the shop
        public static List<Item> CreateNewShop()
        {
            // create a list of item ids
            var itemIds = new List<int>();


            // Badges
            while (itemIds.Count < 4 || itemIds.Count > 7) { // Try to have a reasonable range of items
                itemIds = new List<int>();
                // Very rare
                if (Main.rand.Next(7) == 0) itemIds.Add(ModContent.ItemType<LuckyDay>());
                if (Main.rand.Next(7) == 0) itemIds.Add(ModContent.ItemType<ReturnPostage>());
                if (Main.rand.Next(7) == 0) itemIds.Add(ModContent.ItemType<MegaRush>());
                // Rare
                if (Main.rand.Next(5) == 0) itemIds.Add(ModContent.ItemType<LastStand>());
                if (Main.rand.Next(5) == 0) itemIds.Add(ModContent.ItemType<PUpDDown>());
                if (Main.rand.Next(5) == 0) itemIds.Add(ModContent.ItemType<PDownDUp>());
                if (Main.rand.Next(5) == 0) itemIds.Add(ModContent.ItemType<DangerRush>());
                // Uncommon
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<CloseCall>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<HeartFinder>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<FlowerFinder>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<PayOff>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AngersPower>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<DoubleDip>());
                if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<PiercingBlow>());
                // Common
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<HPPlus>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<FPPlus>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<ISpy>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<DefendPlus>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<SpikeShield>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<SlowGo>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<DoublePain>());
                if (Main.rand.Next(3) == 0) itemIds.Add(ModContent.ItemType<PrettyLucky>());
            }

            // Randomly sell some gag items
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<TriumphantTrumpet>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<SuperAppeal>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXA>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXB>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXC>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXD>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXE>());
            if (Main.rand.Next(4) == 0) itemIds.Add(ModContent.ItemType<AttackFXF>());

            // Create list of items
            var items = new List<Item>();
            foreach (int itemId in itemIds)
            {
                Item item = new Item();
                item.SetDefaults(itemId);
                items.Add(item);
            }
            return items;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            foreach (Item item in shopItems)
            {
                // We dont want "empty" items and unloaded items to appear
                if (item == null || item.type == ItemID.None)
                    continue;

                shop.item[nextSlot].SetDefaults(item.type);
                nextSlot++;
            }
        */

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            // Moonphases, a poor man's RNG
            if (Main.moonPhase < 2)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<LuckyDay>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PUpDDown>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<HeartFinder>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DoubleDip>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ISpy>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DoublePain>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXA>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXE>());
                nextSlot++;
            }
            else if (Main.moonPhase < 4)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ReturnPostage>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PDownDUp>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DodgeMaster>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<FlowerFinder>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PiercingBlow>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DefendPlus>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AmpUp>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<TriumphantTrumpet>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXB>());
                nextSlot++;
            }
            else if (Main.moonPhase < 6)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<MegaRush>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DangerRush>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PayOff>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<HPPlus>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpikeShield>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChillOut>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SuperAppeal>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXC>());
                nextSlot++;
            } else
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<LastStand>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CloseCall>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AngersPower>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<FPPlus>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PrettyLucky>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SlowGo>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXD>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttackFXF>());
                nextSlot++;
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Badge Merchant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 20;
            NPCID.Sets.AttackAverageChance[npc.type] = 100;
            NPCID.Sets.HatOffsetY[npc.type] = 11;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 50;
            npc.lifeMax = 1000;
            npc.defense = 20;
            npc.knockBackResist = 0.7f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = 7;
            animationType = NPCID.Guide;
        }

        public override string TownNPCName()
        {
            return "Charlieton";
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(13))
            {
                case 0:
                    return "Buy a Double Pain today! Limited-time offer! No refunds.";
                case 1:
                    return "HEY-YO! I've got hot, hot products. Get them while they last!";
                case 2:
                    return "Come to score a steal? I change the goods I offer from time to time, so check back often!";
                case 3:
                    return "Hey hey HEY-YO! I've got ALL the hottest new products right here. Look no further!";
                case 4:
                    return "Those coins are burning a hole in your pocket, am I right? HEY-YO! Not to worry champ, Charlieton has everything you need!";
                case 5:
                    return "You ever hear that dry shrooms are a delicacy? Shocker,\nright? I'm feeling generous, so I'll let you have them on the cheap!";
                case 6:
                    return "Dusty Hammers for sale! Only lightly used! These go for a fortune over in Rogueport, you know.";
                case 7:
                    return "Yo yo HEY-YO! Charlieton's the name, selling badges is my game! Do a guy a solid and buy? My kids' tuition won't pay for itself.";
                case 8:
                    return "Don't expect me to have these beauties in stock for long! I got a little red fella waiting in Rogueport waiting to buy\nthese right up!";
                case 9:
                    return "Ever been to the Pit of 100 Trials? I wouldn't recommend\nit. Dark, drab, very few suckers to sell to. I found these quality goods there, though!";
                case 10:
                    return "What's that? Ultra Shrooms? Jammin' Jellies? Sorry, the\nlast guy just bought my whole stock.";
                case 11:
                    return "Can I interest you in badges at practically clearance cost? When they save your bacon, you'll have nobody but\nCharlieton to thank! HEY-YO!";
                default:
                    return "You got the fevered look of a man with a mind for goods!\nWanna buy something?";
            }
        }

        public override void AI()
        {
            npc.homeless = true;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton) shop = true;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.CopperCoin); // Placeholder
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            switch (rangedAttack)
            {
                case 0:
                    damage = 15;
                    knockback = 0f;
                    break;
                case 1:
                    damage = 25;
                    knockback = 1.5f;
                    break;
                case 2:
                    damage = 35;
                    knockback = 3f;
                    break;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {

            //Throws three types of projectiles
            switch (Main.rand.Next(3))
            {
                case 0:
                    projType = ModContent.ProjectileType<DriedShroom>();
                    rangedAttack = 0;
                    break;
                case 1:
                    projType = ModContent.ProjectileType<Mistake>();
                    rangedAttack = 1;
                    break;
                default:
                    projType = ModContent.ProjectileType<DustyHammer>();
                    rangedAttack = 2;
                    break;
            }
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7.5f;
            //gravityCorrection = 2f;
            randomOffset = 4f;
        }

    }
}