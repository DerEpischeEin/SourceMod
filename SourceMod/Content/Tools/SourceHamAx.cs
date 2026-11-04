using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace SourceMod.Content.Tools
{
    public class SourceHamAx : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1000);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.axe = 115;
            Item.hammer = 100;
            Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SourceBar, 30);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 125);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }

    }
}