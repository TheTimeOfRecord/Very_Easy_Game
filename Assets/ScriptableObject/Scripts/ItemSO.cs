using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{ 
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType
{
    Health,
    Speed,
    Jump,
    SteminaBoost
}

public class ItemDataComsumable
{
    public ConsumableType consumableType;
    public float value;
}


[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool CanStack;
    public int maxStackCount;

    [Header("Consumable")]
    public ItemDataComsumable[] itemDataComsumables;

    [Header("Equip")]
    public GameObject equipPrefab;
}
