using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Testmod.Projectiles;

namespace SourceMod.Content.Weapons
{
	public class SourceBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = new SoundStyle("Testmod/Content/Sounds/Items/Corrupt1");
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<sourceSlash>();
			Item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SourceBar, 30);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 100);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}
