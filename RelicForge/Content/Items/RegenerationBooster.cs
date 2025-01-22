using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RelicForge.Content.Items
{
    public class RegenerationBooster : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item4;
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.maxStack = 1;
        }

        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<RegenerationPlayer>().HasUsedRegenerationBooster;
        }

        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<RegenerationPlayer>().HasUsedRegenerationBooster = true;
            return true;
        }
    }

    // Player data for using the Regeneration Booster
    public class RegenerationPlayer : ModPlayer
    {
        public bool HasUsedRegenerationBooster;

        public override void UpdateLifeRegen()
        {
            if (HasUsedRegenerationBooster)
            {
                Player.lifeRegen += 4; // Permanently increases life regen by 2
            }
        }

        public override void SaveData(Terraria.ModLoader.IO.TagCompound tag)
        {
            tag["HasUsedRegenerationBooster"] = HasUsedRegenerationBooster;
        }

        public override void LoadData(Terraria.ModLoader.IO.TagCompound tag)
        {
            HasUsedRegenerationBooster = tag.GetBool("HasUsedRegenerationBooster");
        }
    }
}
