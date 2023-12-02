using UnityEngine;

public class KitchenVisibility : MonoBehaviour
{
    public GameObject kitchenObject;
    private int keyPressCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            keyPressCount++;

            if (keyPressCount >= 2)
            {
                ToggleKitchenVisibility();
            }
        }
    }

    private void ToggleKitchenVisibility()
    {
        // Pokaż lub ukryj obiekt kuchni
        kitchenObject.SetActive(!kitchenObject.activeSelf);

        // Zresetuj licznik po pokazaniu obiektu
        if (kitchenObject.activeSelf)
        {
            keyPressCount = 0;
        }
    }
}
