﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ITEM
public enum E_ELEMENT_TYPE
{
    NONE = 0,
    FIRE,
    WATER,
    NATURE,
    SHINE,
    DARK
}

public enum E_ITEM_TIER
{
    NONE = 0,
    COMMON,
    RARE,
    EPIC,
    LEGEND,
}

public enum E_ITEM_TYPE
{
    NONE = 0,
    EQUIP,
    WEAPON,
    ESSENCE,
    BLESS
}
public enum E_EQUIP_TYPE
{ 
    NONE = 0,
    HELMET,
    ARMOR_TOP,
    ARMOR_PANTS
}

public enum E_WEAPON_TYPE
{
    NONE = 0,
    SWARD,
    BOW,
    WAND,

}

public enum E_ATTACK_TYPE
{
    PHYSICAL,
    MAGICAL
}

#endregion