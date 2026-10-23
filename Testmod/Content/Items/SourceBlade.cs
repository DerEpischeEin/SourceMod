using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Testmod.Projectiles;

namespace Testmod.Content.Items
{
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class SourceBlade : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Testmod.hjson' file.
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
			Item.UseSound = new SoundStyle("Testmod/Sounds/Items/Corrupt1");
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<sourceSlash>();
			Item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
