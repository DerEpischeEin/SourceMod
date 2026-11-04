using SourceMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SourceMod.Content.Weapons
{
    public class SourceRifle : ModItem
    {
        public override void SetDefaults(){
            Item.width = 62;
            Item.height = 32;
            Item.scale = 0.75f;
            Item.rare = ItemRarityID.Purple;
            Item.useTime = 6;
            Item.useAnimation = 18;
            Item.reuseDelay = 20;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 30
            Item.knockBack = 2f;
            Item.noMelee = true;
            Item.shoot = mod.ProjectileType("SourceBullet");
            Item.shootSpeed = 7f;
            Item.useAmmo = mod.ItemType("SourceBullet");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 200);
            recipe.AddIngredient(ItemID.SourceBar, 30);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}