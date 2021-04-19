# Terraria-Prefixes
A code sample repository, containing samples of prefixes for terraria modding.

Mod available in the TModLoader mod browser

## What is a Prefix?
A prefix in Terraria are those words that comes before weapons, like "legendary", "ruthless", "godly", "demonic", "etc".

## How to make a Prefix?
Simply having a class that extends `ModPrefix` will create a default implementation of a prefix, available in your Mod.
However the name of the prefix will simply be the name of your class and it will not modify the stats at all.

We can change the name of the prefix, and use it to modify shooting speed, damage, size, etc of an item.
To see a very basic implementation of a Prefix, look at Doge.cs

## Prefix stats
The primary purpose of prefixes are to change the stats of an item, and also its value(Items with certain prefixes may cost more than items with other prefixes).
By default, the value multiplier(how much more money it will cost for selling or reforging) of an item will be calculated based on the stat increase it provides, however you may set your own value multiplier by overriding the `ModifyValue()` method, so you could end up with a really powerful weapon that is really cheap.

Setting the stat multipliers for an item with the prefix is done in the appropriately named `SetStats()` method, just override and set stat values.
Note that the `PrefixCatgeory` enum (Which is set to `PrefixCategory.Custom` by default) changes your ability to set the stat multipliers, for example, if you set the enum to say PrefixCategory.Melee, then you will be able to change the scale multiplier (to increase or decrease the size of a weapon) or if you set it to PrefixCategory.Ranged, you would be able to change the shoot speed multiplier of that item.
