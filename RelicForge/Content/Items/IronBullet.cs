using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class IronBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 6; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<Projectiles.IronBulletProjectile>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4.5f; // The speed of the projectile. This value equivalent to Silver Bullet since ExampleBullet's Projectile.extraUpdates is 1.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            // Recipe for crafting with Iron Ore
            Recipe recipe1 = CreateRecipe(25);
            recipe1.AddIngredient(Terraria.ID.ItemID.IronOre, 1); // 1 Iron Ore
            recipe1.AddTile(Terraria.ID.TileID.Anvils); // Crafting station: Anvil
            recipe1.Register();

            // Recipe for crafting with Lead Ore
            Recipe recipe2 = CreateRecipe(25);
            recipe2.AddIngredient(Terraria.ID.ItemID.LeadOre, 1); // 1 Lead Ore
            recipe2.AddTile(Terraria.ID.TileID.Anvils); // Crafting station: Anvil
            recipe2.Register();
        }
    }
}
