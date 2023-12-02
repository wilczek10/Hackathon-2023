using UnityEngine;

public class ExpandCanvasOnKeyPress : MonoBehaviour
{
    public Canvas canvasToExpand;
    public RectTransform square1;

    void Start()
    {
        // Wyłącz canvas na początku
        if (canvasToExpand != null)
        {
            canvasToExpand.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleCanvasAndExpand();
        }
    }

    void ToggleCanvasAndExpand()
    {
        if (canvasToExpand != null && square1 != null)
        {
            // Zmień stan aktywności canvas
            canvasToExpand.enabled = !canvasToExpand.enabled;

            if (canvasToExpand.enabled)
            {
                // Pobierz rozmiar ekranu
                Vector2 screenSize = new Vector2(Screen.width, Screen.height);

                // Ustaw rozmiar i pozycję square1 tak, aby wypełniał cały ekran
                square1.sizeDelta = screenSize;
                square1.anchoredPosition = screenSize / 2f;
            }
        }
        else
        {
            Debug.LogError("Canvas or square1 is not assigned.");
        }
    }
}
