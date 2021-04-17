using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Prefixes.Prefixes
{
    //A collection of prefixes designed for melee weapons
    public class Temperature: ModPrefix
    {

        private string name = string.Empty;
        private float damage = 1f;

        //must have public parameterless constructor defined
        public Temperature()
        {
        }

        public Temperature(string name, float scale)
        {
            this.name = name;
            this.damage = scale;
        }

        public override bool CanRoll(Item item)
        {
            if (item.melee)
            {
                return true;
            }
            return false;
        }


        //Set to 1 by default
        public override float RollChance(Item item) => 2f;

        //This means we are allowed to change the size of this item
        public override PrefixCategory Category => PrefixCategory.Melee;

        public override bool Autoload(ref string name)
        {
            //first is the internal name, the second is the display name
            mod.AddPrefix("Frigid", new Metric("Frigid", 1.5f));
            mod.AddPrefix("Cold", new Metric("Cold", 1.25f));
            mod.AddPrefix("Lukewarm", new Metric("Lukewarm", 1.1f));
            mod.AddPrefix("Hot", new Metric("Hot", 1.25f));
            mod.AddPrefix("Searing", new Metric("Searing", 1.6f));

            return false;
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault(name);
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = damage;
        }

    }
}
