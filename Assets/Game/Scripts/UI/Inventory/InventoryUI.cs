using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    PlayerInventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<InventorySlot> GetInventorySlots(E_INVENTORY_SLOT_TYPE _eType)
    {
        List<InventorySlot> result = new List<InventorySlot>();

        var info = from n in slots
                   where (n.eSlotType == _eType)
                   select n;

        result = info.ToList();

        return result;
    }

    void UpdateUI()
    {

        for(int i = 0; i < 8; ++i)
        {
            var eType = OS.BitConvert.IntToEnum32<E_INVENTORY_SLOT_TYPE>(i);
            UpdateUI(eType);

        }

        Debug.Log("UPDATING UI " + gameObject.name);
    }

    void UpdateUI( E_INVENTORY_SLOT_TYPE _eType)
    {

        var listItem = inventory.GetItemInfos(_eType);
        var listSlot = GetInventorySlots(_eType);

        for (int i = 0; i < listSlot.Count; ++i)
        {
            var slot = listSlot[i];
            if (i >= listItem.Count)
            {
                slot.ClearSlot();
                continue;
            }

            ItemInfo info = listItem[i];

            slot.AddItem(info);

        }
    }
}
