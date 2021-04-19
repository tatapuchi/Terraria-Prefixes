# Basic Information
A code sample repository, containing samples of prefixes for terraria modding.

Mod available in the TModLoader mod browser

## What is a Prefix?
A prefix in Terraria are those words that comes before weapons, like "legendary", "ruthless", "godly", "demonic", "etc".

## How to make a Prefix?
Simply having a class that extends `ModPrefix` will create a default implementation of a prefix, available in your Mod.
However the name of the prefix will simply be the name of your class and it will not modify the stats at all.

We can change the name of the prefix, and use it to modify shooting speed, damage, size, etc of an item.
To see a very basic implementation of a Prefix, look at **`Doge.cs`**

## Prefix stats
The primary purpose of prefixes are to change the stats of an item, and also its value(Items with certain prefixes may cost more than items with other prefixes).
By default, the value multiplier(how much more money it will cost for selling or reforging) of an item will be calculated based on the stat increase it provides, however you may set your own value multiplier by overriding the `ModifyValue()` method, so you could end up with a really powerful weapon that is really cheap.

Setting the stat multipliers for an item with the prefix is done in the appropriately named `SetStats()` method, just override and set stat values.
Note that the `PrefixCatgeory` enum (Which is set to `PrefixCategory.Custom` by default) changes your ability to set the stat multipliers, for example, if you set the enum to say PrefixCategory.Melee, then you will be able to change the scale multiplier (to increase or decrease the size of a weapon) or if you set it to PrefixCategory.Ranged, you would be able to change the shoot speed multiplier of that item.

# Methods

## RollChance()
This should be easy to understand, it is just the chance that your prefix will be rolled compared to a vanilla prefix.  
The method takes in the item to be rolled, so you can change the roll chance depending on the item.  
**The default value is 1f, which is the same as a vanilla prefix**  
**A value of 0f can still be rolled**

```cs
//Default implementation with a roll chance twice that of a vanilla prefix
public override float RollChance(Item item) => 2f;
```

```cs
public override float RollChance(Item item)
{
    if(item.ID = ItemID.Starwrath)
    {
    return 8f;
    }
    return 1f;
}

```


For testing I generally set the chance to be really high so that I can easily reforge and get it.

## CanRoll()
This method allows us to set whether a prefix can be rolled or not, obviously this may seem stupid because we want our prefix to be rolled, but if you want to implement a check to see whether our weapon is the correct type or not we would do it here. For example, we have a prefix called "deflated" for ball type weapons, we do not want this appearing on all throwing weapons because a "deflated" throwing knife doesn't even make sense.  
This method takes in the item to be rolled, so we can use that to check for a certain item type.
**By default CanRoll() returns true depending on the RollChance()**

```cs
//Default implementation (Not required as it is true by default)
public override bool CanRoll(Item item) => true;
```

```cs
//Check for a certain item
public override bool CanRoll(Item item)
{
    if(item.ID == ItemID.Meowmere)
    {
    return true;
    }
    return false;
}
```

## SetDefaults
This is the method where you can set your item's display name, if you do not want it to be the same as the name of your class(eg: maybe you want a space in it, or an apostrophe).


## Autoload()
This method actually allows to to create mutliple prefixes in the same class, say we had a specific type of prefix like something for size: "Small", "Medium", "Big"
All these methods would do is the scale of the item, and so, instead of having one class for each, we can group them in one class that defines all three prefixes, look to **`Metric.cs`** for an example on this.
