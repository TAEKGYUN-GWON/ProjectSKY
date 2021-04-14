using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    ItemInfo item = null;

    public E_INVENTORY_SLOT_TYPE eSlotType = E_INVENTORY_SLOT_TYPE.NONE;

    public void AddItem(ItemInfo _newItem)
    {
        item = _newItem;
        icon.sprite = item.Icon;
        icon.rectTransform.sizeDelta = item.Icon.rect.size;
        icon.rectTransform.localScale = new Vector3(2, 2, 0);
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
