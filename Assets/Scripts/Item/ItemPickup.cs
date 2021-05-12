using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemInfo item = null;
    public SpriteRenderer sprite = null;
    public List<ItemInfo> itemList = new List<ItemInfo>();
    public E_ITEM_TIER eTier = E_ITEM_TIER.NONE;
    public E_ITEM_TYPE eType = E_ITEM_TYPE.NONE;

    private void Awake()
    {
        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (itemList.Count > 0)
            SetRandomItemFromList();
        else
            SetRandomItem();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.05f);

    }

    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up item. name : " + name);

        bool wasPickedUp = PlayerInventory.Instance.AddItem(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }

    void SetRandomItem()
    {
        itemList = ItemManager.Instance.GetItemsFromTier(GetRandomItemTier(), GetRandomItemType());

        int randItemIdx = Random.Range(0, itemList.Count - 1);

        ItemInfo randItem = null;

        if (randItemIdx < itemList.Count)
            randItem = itemList[randItemIdx];

        item = randItem;
        sprite.sprite = item.Icon;
    }

    void SetRandomItemFromList()
    {
        int randItemIdx = Random.Range(0, itemList.Count - 1);

        ItemInfo randItem = null;

        if (randItemIdx < itemList.Count)
            randItem = itemList[randItemIdx];

        item = randItem;

        sprite.sprite = item.Icon;
    }

    E_ITEM_TIER GetRandomItemTier()
    {
        if (eTier != E_ITEM_TIER.NONE)
            return eTier;

        //int randPerTier = Random.Range(1, 101);

        //if (randPerTier > 0 && randPerTier <= 60)
        //{
        //    eTier = E_ITEM_TIER.COMMON;
        //}
        //else if (randPerTier > 60 && randPerTier <= 85)
        //{
        //    eTier = E_ITEM_TIER.RARE;
        //}
        //else if (randPerTier > 85 && randPerTier <= 98)
        //{
        //    eTier = E_ITEM_TIER.EPIC;
        //}
        //else if (randPerTier > 98 && randPerTier <= 100)
        //{
        //    eTier = E_ITEM_TIER.LEGEND;
        //}

        int randPerTier = Random.Range(1, 5);
        eTier = OS.BitConvert.IntToEnum32<E_ITEM_TIER>(randPerTier);
        return eTier;
    }
    E_ITEM_TYPE GetRandomItemType()
    {
        if (eType != E_ITEM_TYPE.NONE)
            return eType;

        int randPerType = Random.Range(1, 3);

        if (randPerType == 1)
        {
            eType = E_ITEM_TYPE.EQUIP;
        }
        else if (randPerType == 2)
        {
            eType = E_ITEM_TYPE.WEAPON;
        }
        else if (randPerType == 3)
        {
            eType = E_ITEM_TYPE.ESSENCE;
        }
        else if (randPerType == 4)
        {
            eType = E_ITEM_TYPE.BLESS;
        }

        return eType;
    }
}
