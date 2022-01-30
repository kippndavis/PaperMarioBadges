using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PaperMarioBadges
{
    public class PaperMarioBadges : Mod
    {

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte msgType = reader.ReadByte();
            switch (msgType)
            {
                case 0: // Return Postage NPCStrike

                    int returnDamage = reader.ReadInt32();
                    NPC npc = Main.npc[reader.ReadByte()];

                    if (Main.netMode == NetmodeID.Server)
                    {
                        npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                        ModPacket packet = this.GetPacket();
                        packet.Write((byte)0);
                        packet.Write(returnDamage);
                        packet.Write((byte)npc.whoAmI);
                        packet.Send(-1, whoAmI);
                    }
                    else
                    {
                        npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                    }
                    break;
                default:
                    Logger.WarnFormat("PaperMarioBadges: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }
}

            /* Example Send & Receieve
            public override void HandlePacket(BinaryReader reader, int whoAmI)
            {
            }

            public void Send(int toWho, int fromWho)
            {
                ModPacket packet = this.GetPacket();
                if (Main.netMode == NetmodeID.Server)
                {
                    packet.Write(fromWho);
                }
                packet.Write(someVal);
                packet.Write(someInt);
                packet.Send(toWho, fromWho);
            }

            public void Receive(BinaryReader reader, int fromWho)
            {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    fromWho = reader.ReadInt32();
                }
                someVal = reader.ReadSingle();
                someInt = reader.ReadInt32();
                if (Main.netMode == NetmodeID.Server)
                {
                    Send(-1, fromWho);
                }
                else
                {
                    modPlayer mPlayer = Main.player[fromWho].GetModPlayer<modPlayer>();
                    mPlayer.someVal = false;
                }
            }

            */

        // Override this method to handle network packets sent for this mod.
        //TODO: Introduce OOP packets into tML, to avoid this god-class level hardcode.
        /*
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte msgType = reader.ReadByte();
            switch (msgType)
            {
                case 0: // Return Postage NPC Effect

                    int returnDamage = reader.ReadInt32();
                    NPC npc = Main.npc[reader.ReadByte()];


                    if (Main.netMode == NetmodeID.Server)
                    {
                        npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                        //npc.checkDead();
                        //Packets packets;
                        //packets.Send(-1, whoAmI);
                    }
                    else
                    {
                        //npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                        //int returnDamage = reader.ReadInt32();
                        //NPC npc = Main.npc[reader.ReadByte()];
                        //npc.StrikeNPCNoInteraction(returnDamage, 0f, 0, false, false, false);
                    }
                    break;
                default:
                    Logger.WarnFormat("PaperMarioBadges: Unknown Message type: {0}", msgType);
                    break;
            }
        }
        */