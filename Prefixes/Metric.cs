using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Prefixes.Prefixes
{
    //A general collection of prefixes designed to modify the sizes of weapons
    public class Metric : ModPrefix
    {

        private string name = string.Empty;
        private float scale = 1f;

        //must have public parameterless constructor defined
        public Metric()
        {
        }

        public Metric(string name, float scale)
        {
            this.name = name;
            this.scale = scale;
        }

        //Will be true by default if the RollChance is greater than 0
        public override bool CanRoll(Item item)
        {
            return true;
        }


        //Set to 1 by default
        public override float RollChance(Item item) => 2f;

        //Set to PrefixCategory.Custom by default
        public override PrefixCategory Category => PrefixCategory.AnyWeapon;

        public override bool Autoload(ref string name)
        {
            //first is the internal name, the second is the display name
            mod.AddPrefix("Pico", new Metric("Pico", 0.4f));
            mod.AddPrefix("Nano", new Metric("Nano", 0.5f));
            mod.AddPrefix("Micro", new Metric("Micro", 0.6f));
            mod.AddPrefix("Milli", new Metric("Milli", 0.7f));
            mod.AddPrefix("Centi", new Metric("Centi", 0.8f));
            mod.AddPrefix("Deci", new Metric("Deci", 0.9f));

            mod.AddPrefix("Deca", new Metric("Deca", 1.1f));
            mod.AddPrefix("Hecto", new Metric("Hecto", 1.2f));
            mod.AddPrefix("Kilo", new Metric("Kilo", 1.3f));
            mod.AddPrefix("Mega", new Metric("Mega", 1.6f));
            mod.AddPrefix("Giga", new Metric("Giga", 1.9f));
            mod.AddPrefix("Tera", new Metric("Tera", 2.1f));
            mod.AddPrefix("Peta", new Metric("Peta", 2.4f));

            return false;
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault(name);
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            scaleMult = scale;
        }

    }

}
