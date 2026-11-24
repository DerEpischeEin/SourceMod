using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SourceMod.Content.Effects
{
    internal class  CorruptionEffect : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Corruption");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0) {
                player.lifeRegen = 0;
            }
            player.lifeRegen -= 40;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0) {
                npc.lifeRegen = 0;
            }

            npc.lifeRegen -= 40;
        }
    }
}