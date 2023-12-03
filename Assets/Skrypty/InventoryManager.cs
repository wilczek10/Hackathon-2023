using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryCanvas;
    private bool isInventoryOpen = false;

    void Start()
    {
        inventoryCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory() // Zmiana na public
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryCanvas.SetActive(isInventoryOpen);
    }
}