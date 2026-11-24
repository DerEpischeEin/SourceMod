using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SourceMod.Content.Items
{
	public class SourceBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 999;
		}

		public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true; 
			Item.knockBack = 1.5f;
			Item.value = 10000;
            Item.rare = ItemRarityID.Lime;
			Item.shoot = ModContent.ProjectileType<Projectiles.SourceBullet>(); 
			Item.shootSpeed = 2.5f * 6; 
			Item.ammo = AmmoID.Bullet; 
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.SourceBar>(), 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 100);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
	}
}
