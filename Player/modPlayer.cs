using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

using PaperMarioBadges.Projectiles;
using PaperMarioBadges.Buffs;
using PaperMarioBadges.NPCs;

namespace PaperMarioBadges.Items
{
    public class modPlayer : ModPlayer
    {
        public static int direction = 0;
        public bool doublePainItem = false;
        public bool payOffItem = false;
        public bool slowGoItem = false;
        public bool slowGoBonus = false;
        public bool slowGoWingBonus = false;
        public bool spikeShieldItem = false;
        public bool angersWrathItem = false;
        public bool lastStandItem = false;
        public bool megaRushItem = false;
        public bool dangerRushItem = false;
        public bool iSpyItem = false;
        public bool pDownDUpItem = false;
        public bool pUpDDownItem = false;
        public bool heartFinderItem = false;
        public bool flowerFinderItem = false;
        public bool returnPostageItem = false;
        public int returnPostageDamage = 0;
        public int returnPostageLife = 0;
        public bool defendPlusItem = false;
        public bool luckyDayItem = false;
        public bool prettyLuckyItem = false;
        public bool closeCallItem = false;
        public bool luckyProc = false;
        public bool doubleDipItem = false;
        public bool piercingBlowItem = false;
        public bool superAppealItem = false;
        public bool attackFXAItem = false;
        public bool attackFXBItem = false;
        public bool attackFXCItem = false;
        public bool attackFXDItem = false;
        public bool attackFXEItem = false;
        public bool attackFXFItem = false;
        public bool chillOutItem = false;
        public bool ampUpItem = false;
        public bool dodgeMasterItem = false;
        public int dodgeMasterCooldown = 0;
        public bool showDanger = true;
        public bool showPeril = true;
        public float lifePercentage = 0.0f;
        public int payOffCooldown = 0; // 5 mins
        public int doubleDipHealingCooldown = 1800; // 5 mins
        public int doubleDipManaCooldown = 1800; // 5 mins
        public int iSpyCooldown = 3600; // 5 mins
        public int angersWrathCooldown = 0; // 10 seconds

        public override void ResetEffects()
        {
            doublePainItem = false;
            payOffItem = false;
            slowGoItem = false;
            spikeShieldItem = false;
            angersWrathItem = false;
            lastStandItem = false;
            megaRushItem = false;
            dangerRushItem = false;
            iSpyItem = false;
            pDownDUpItem = false;
            pUpDDownItem = false;
            heartFinderItem = false;
            flowerFinderItem = false;
            returnPostageItem = false;
            defendPlusItem = false;
            luckyDayItem = false;
            prettyLuckyItem = false;
            closeCallItem = false;
            doubleDipItem = false;
            piercingBlowItem = false;
            superAppealItem = false;
            attackFXAItem = false;
            attackFXBItem = false;
            attackFXCItem = false;
            attackFXDItem = false;
            attackFXEItem = false;
            attackFXFItem = false;
            chillOutItem = false;
            ampUpItem = false;
            dodgeMasterItem = false;
    }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {

            luckyProc = false;

            if (dodgeMasterItem && dodgeMasterCooldown <= 0 && (luckyDayItem || (closeCallItem && lifePercentage <= 0.5) || prettyLuckyItem))
            {
                dodgeMasterCooldown = 3600;
                hitDirection = 0;
                luckyProc = true;
                player.AddBuff(mod.BuffType("Dodge"), (player.longInvince ? 120 : 80));
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Lucky"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<LuckyDayAnim>(), 0, 0f);
                return false;
            }

            if (luckyDayItem && Main.rand.Next(6) == 0)
            {
                playSound = false;
                hitDirection = 0;
                luckyProc = true;
                player.AddBuff(mod.BuffType("Dodge"), (player.longInvince ? 120 : 80));
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Lucky"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<LuckyDayAnim>(), 0, 0f);
                return false;
            }

            if (closeCallItem && Main.rand.Next(9) == 0 && lifePercentage <= 0.5)
            {
                playSound = false;
                hitDirection = 0;
                luckyProc = true;
                player.AddBuff(mod.BuffType("Dodge"), (player.longInvince ? 120 : 80));
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Lucky"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<LuckyDayAnim>(), 0, 0f);
                return false;
            }

            if (prettyLuckyItem && Main.rand.Next(12) == 0)
            {
                playSound = false;
                hitDirection = 0;
                luckyProc = true;
                player.AddBuff(mod.BuffType("Dodge"), (player.longInvince ? 120 : 80));
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Lucky"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<LuckyDayAnim>(), 0, 0f);
                return false;
            }

            if (doublePainItem) // Apply this before any reductions
            {
                damage *= 2;
            }

            if (lastStandItem && (damage >= player.statLife) && lifePercentage >= 0.5)
            {
                damage = player.statLife - 1; // Reduce player life to 1
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Block"));
                Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<LastStandBlock>(), 0, 0f);
            } else if (lastStandItem && lifePercentage < 0.5)
            {
                damage = (int)(damage * 0.75);
            }

            if (defendPlusItem)
            {
                damage = (int)(damage * 0.95);
            }

            if (spikeShieldItem && (damageSource.SourceProjectileType == ProjectileID.Boulder || damageSource.SourceProjectileType == ProjectileID.PoisonDart))
            {
                damage = (int)(damage * 0.25);
            }

            if (payOffItem && payOffCooldown <= 0 && Main.rand.Next(50) == 0)
            {
                payOffCooldown = 18000;
                if (doublePainItem)
                {
                    if (Main.rand.Next(50) == 0) {
                            Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y - 50, 0, 0, ModContent.ProjectileType<PlatPortalAnim>(), 0, 0f);
                    } else {
                        Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y - 50, 0, 0, ProjectileID.CoinPortal, 0, 0f);
                    }
                } else {
                     if (Main.rand.Next(100) == 0)
                     {
                         Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y - 50, 0, 0, ModContent.ProjectileType<PlatPortalAnim>(), 0, 0f);
                     } else {
                         Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y - 50, 0, 0, ProjectileID.CoinPortal, 0, 0f);
                     }
                }
            }

            if (returnPostageItem && damageSource.SourceNPCIndex != -1)
            {
                returnPostageDamage = damage;
                returnPostageLife = player.statLife;
                player.statLife += damage; // Preemptively heal to prevent lethal damage; see OnHitByNPC
            }

            return true;
        }

        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            if (pDownDUpItem && !pUpDDownItem)
            {
                mult *= 0.80f;
            }

            if (pUpDDownItem && !pDownDUpItem)
            {
                mult *= 1.20f;
            }

            if (dangerRushItem && ((megaRushItem && (lifePercentage <= 0.5 && lifePercentage > 0.25)) || (!megaRushItem && lifePercentage <= 0.5)))
            {
                mult *= 1.33f;
            }
            
            if (megaRushItem && doublePainItem && lifePercentage <= 0.25)
            {
                mult *= 1.50f;
                player.meleeCrit = 100;
                player.rangedCrit = 100;
                player.magicCrit = 100;
            } else if (megaRushItem && lifePercentage <= 0.25)
            {
                mult *= 1.50f;
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (target.HasBuff(mod.BuffType("PiercingBlow")) || piercingBlowItem)
            {
                if (target.defense >= 20)
                {
                    damage += 10;
                }
                else
                {
                    damage += (int)(target.defense * 0.5);
                }
                knockback *= 1.5f;
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.HasBuff(mod.BuffType("PiercingBlow")) || piercingBlowItem)
            {
                if (target.defense >= 20)
                {
                    damage += 10;
                }
                else
                {
                    damage += (int)(target.defense * 0.5);
                }
                knockback *= 1.5f;
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (heartFinderItem)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(target.getRect(), ItemID.Heart);
                }
            }

            if (flowerFinderItem)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(target.getRect(), ItemID.Star);
                }
            }

            if (piercingBlowItem)
            {
                target.AddBuff(mod.BuffType("PiercingBlow"), 300);
            }

            if (attackFXAItem || attackFXBItem || attackFXCItem || attackFXDItem || attackFXEItem || attackFXFItem) // If any are equipped
            {
                int equipped = 0;
                var badges = new List<String>();
                // Add equipped sound paths to a list
                if (attackFXAItem) { equipped++; badges.Add("Sounds/AttackFXA"); }
                if (attackFXBItem) { equipped++; badges.Add("Sounds/AttackFXB"); }
                if (attackFXCItem) { equipped++; badges.Add("Sounds/AttackFXC"); }
                if (attackFXDItem) { equipped++; badges.Add("Sounds/AttackFXD"); }
                if (attackFXEItem) { equipped++; badges.Add("Sounds/AttackFXE"); }
                if (attackFXFItem) { equipped++; badges.Add("Sounds/AttackFXF"); }

                int randomSelect = Main.rand.Next(equipped);
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, badges[randomSelect])); // Play a random sound based on equipped

            }

            if (superAppealItem && 0 >= target.life)
            {

                switch (Main.rand.Next(6))
                {

                    case 0:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer1"));
                        break;
                    case 1:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer2"));
                        break;
                    case 2:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer3"));
                        break;
                    case 3:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer4"));
                        break;
                    case 4:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer5"));
                        break;
                    default:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer6"));
                        break;
                }
            }

        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (heartFinderItem)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(proj.getRect(), ItemID.Heart);
                }
            }

            if (flowerFinderItem)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(proj.getRect(), ItemID.Star);
                }
            }

            if (piercingBlowItem)
            {
                target.AddBuff(mod.BuffType("PiercingBlow"), 300);
            }

            if (attackFXAItem || attackFXBItem || attackFXCItem || attackFXDItem || attackFXEItem || attackFXFItem) // If any are equipped
            {
                int equipped = 0;
                var badges = new List<String>();
                // Add equipped sound paths to a list
                if (attackFXAItem) { equipped++; badges.Add("Sounds/AttackFXA"); }
                if (attackFXBItem) { equipped++; badges.Add("Sounds/AttackFXB"); }
                if (attackFXCItem) { equipped++; badges.Add("Sounds/AttackFXC"); }
                if (attackFXDItem) { equipped++; badges.Add("Sounds/AttackFXD"); }
                if (attackFXEItem) { equipped++; badges.Add("Sounds/AttackFXE"); }
                if (attackFXFItem) { equipped++; badges.Add("Sounds/AttackFXF"); }

                int randomSelect = Main.rand.Next(equipped);
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, badges[randomSelect])); // Play a random sound based on equipped

            }

            if (superAppealItem && 0 >= target.life)
            {
                switch (Main.rand.Next(6))
                {

                    case 0:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer1"));
                        break;
                    case 1:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer2"));
                        break;
                    case 2:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer3"));
                        break;
                    case 3:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer4"));
                        break;
                    case 4:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer5"));
                        break;
                    default:
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Cheer6"));
                        break;
                }
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (returnPostageItem && !luckyProc) // If player dodges, no thorns effect
            {
                int returnDamage = (returnPostageDamage * 2);
                npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                if (npc.life <= 0)
                {
                    //if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Incoming damage was: " + returnPostageDamage + " | NPC Life was " + npc.life + " | returnDamage was " + returnDamage + " | NPC Defense was " + npc.defense, 50, 125, 255);
                    Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<NoDamageAnim>(), 0, 0f);
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/NoDamage"));
                    player.statLife = returnPostageLife;
                }
                else
                {
                    if ((player.statLife - damage) <= 0)
                    {
                        for (int i = 0; i < 200; i++) // Loop through NPC slots to find matching type
                        {
                            if (Main.npc[i].type == npc.type)
                            {
                                player.KillMe(PlayerDeathReason.ByNPC(i), damage, 0);
                            }
                            else if (i == 199)
                            {
                                player.KillMe(PlayerDeathReason.LegacyDefault(), damage, 0);
                            }
                        }
                    }
                    else
                    {
                        player.statLife -= returnPostageDamage;
                    }
                }
            }
        }

        public override void PostUpdate()
        {

            // Get life % as float
            float statLife = player.statLife;
            float statLifeMax = player.statLifeMax;
            lifePercentage = statLife / statLifeMax;

            // Get facing direction
            direction = player.direction;

            // Tick cooldowns
            payOffCooldown--;
            iSpyCooldown--;
            doubleDipHealingCooldown--;
            doubleDipManaCooldown--;
            angersWrathCooldown--;
            dodgeMasterCooldown--;

            if (lifePercentage > 0.5)
            {
                showDanger = true;
                showPeril = true;
            }

            if (dangerRushItem && ((!megaRushItem && lifePercentage <= 0.5) || (megaRushItem && lifePercentage <= 0.5 && lifePercentage > 0.25))) 
            {
                if (showDanger) // Only play once
                {
                    showDanger = false;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Danger"));
                    Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<Danger>(), 0, 0f);
                }
            }

            if (megaRushItem && lifePercentage <= 0.25)
            {
                if (showPeril) // Only play once
                {
                    showPeril = false;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Peril"));
                    Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<Peril>(), 0, 0f);
                }
            }

            if (doubleDipItem && player.HasBuff(21) && doubleDipHealingCooldown <= 0)
            {
                player.DelBuff(player.FindBuffIndex(21));
                player.potionDelay = 0;
                doubleDipHealingCooldown = 18000;
            }

            if (doubleDipItem && player.HasBuff(94) && doubleDipManaCooldown <= 0)
            {
                player.DelBuff(player.FindBuffIndex(94));
                doubleDipManaCooldown = 18000;
            }

            if (angersWrathItem)
            {
                player.AddBuff(115, 1);
                player.AddBuff(117, 1);
                if (angersWrathCooldown <= 0 && Main.rand.Next(2000) == 0)
                {
                    angersWrathCooldown = 600;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/QuestionMark"));
                    Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<AngersPowerQ>(), 0, 0f);
                    int debuff = Main.rand.Next(3);
                    if (debuff == 0)
                    {
                        player.AddBuff(31, 300);
                    }
                    else if (debuff == 1)
                    {
                        player.AddBuff(35, 300);
                    }
                    else
                    {
                        player.AddBuff(23, 300);
                    }
                }
            }

            if (iSpyItem)
            {
                if (doublePainItem)
                {
                    player.AddBuff(9, 1);
                    player.AddBuff(17, 1);
                    player.AddBuff(111, 1);
                } else
                {
                    if (iSpyCooldown <= 0 && Main.rand.Next(36000) == 0)
                    {
                        iSpyCooldown = 36000;
                        Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, 0, ModContent.ProjectileType<ISpyAnim>(), 0, 0f);
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Twinkle"));
                        player.AddBuff(9, 18000);
                        player.AddBuff(17, 18000);
                        player.AddBuff(111, 18000);
                    }
                }
            }

            if (doublePainItem && slowGoItem)
            {
                slowGoBonus = true;
                if (!slowGoWingBonus && player.wingTime <= (int)(player.wingTimeMax * 0.25)) { // My ghetto implementation of 75% longer wing duration
                    slowGoWingBonus = true;
                    player.wingTime = player.wingTimeMax - 1;
                } else if (player.wingTime == player.wingTimeMax && slowGoWingBonus) // Once player lands, allow the bonus again
                {
                    slowGoWingBonus = false;
                }
            }
            else if (slowGoItem)
            {
                slowGoBonus = false;
            }

        }

        public override void PostUpdateEquips()
        {
            if (pDownDUpItem && !pUpDDownItem)
            {
                player.statDefense = (int)(player.statDefense * 1.20);
            }
            if (pUpDDownItem && !pDownDUpItem)
            {
                player.statDefense = (int)(player.statDefense * 0.80);
            }
        }
    }
}

            
        