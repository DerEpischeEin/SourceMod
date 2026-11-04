using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SourceMod.Content.Weapons
{
	public class Execution : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 100000000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SourceBar, 9999);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}
