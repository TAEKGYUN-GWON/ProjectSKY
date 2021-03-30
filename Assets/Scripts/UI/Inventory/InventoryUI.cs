using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    PlayerInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
    }
}
