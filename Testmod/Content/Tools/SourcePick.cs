using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace Testmod.Content.Tools
{
    public class SourcePick : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1000);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.pick = 210;
            Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amber, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 100);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }

    }
}