using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Prefixes.Prefixes
{
    //A very general bare bones implementation of a ModPrefix designed for any 
    public class Doge: ModPrefix
    {
        public Doge()
        {

        }

        //This prefix can be applied to any weapon
        public override PrefixCategory Category => PrefixCategory.AnyWeapon;

        //Here we set the name of the prefix, without this method, the name defaults to the name of the class (in our case this would be Doge).
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Doge's");
        }

        //Here we set the stat multipliers of the prefix
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.2f;
            knockbackMult = 2f;
            scaleMult = 1.3f;
        }
    }
}
