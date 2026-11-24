using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace SourceMod.Content.Items
{
    public class SourceBar : ModItem
    {
        public override void SetStaticDefaults(){
            Item.ResearchUnlockCount = 300;
            ItemID.Sets.SortingPriorityMaterials[Type] = 100;
            Item.rare = ItemRarityID.Lime;
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 30, ItemID.BeetleHusk, 10);
        }

        public override void SetDefaults(){
            Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.SourceBar>());
            Item.width = 20;
            Item.height = 20;
            Item.value = 1000000;
        }
    }
}