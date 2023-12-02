using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageWithButtons : MonoBehaviour
{
    public Image imageToChange;
    public Sprite[] imageOptions;
    private int correctImageIndex = 3; // Indeks poprawnego winyla (indeksy zaczynają się od 0)
    private int selectedImageIndex = -1; // Indeks zaznaczonego winyla (-1 oznacza, że nie wybrano jeszcze żadnego)

    public Image correctnessIndicator; // Dodatkowy obiekt do pokazywania poprawności
    public Sprite correctIndicatorSprite;
    public Sprite incorrectIndicatorSprite;

    private bool confirmationMode = false; // Flaga trybu potwierdzenia

    void Start()
    {
        UpdateImage();
    }

    public void OnRightButtonClicked()
    {
        selectedImageIndex = (selectedImageIndex + 1) % imageOptions.Length;
        UpdateImage();
    }

    public void OnLeftButtonClicked()
    {
        selectedImageIndex = (selectedImageIndex - 1 + imageOptions.Length) % imageOptions.Length;
        UpdateImage();
    }

    void UpdateImage()
{
    if (imageOptions.Length > 0 && imageToChange != null)
    {
        if (imageToChange.sprite != null)
        {
            imageToChange.sprite = imageOptions[selectedImageIndex];

            // Sprawdź poprawność i aktualizuj wskaźnik poprawności
            if (confirmationMode)
            {
                if (selectedImageIndex == correctImageIndex)
                {
                    correctnessIndicator.sprite = correctIndicatorSprite;
                }
                else
                {
                    correctnessIndicator.sprite = incorrectIndicatorSprite;
                }

                // Zakończ tryb potwierdzenia po naciśnięciu "Q" ponownie
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    confirmationMode = false;
                }
            }
            else
            {
                correctnessIndicator.sprite = null;

                // Rozpocznij tryb potwierdzenia po naciśnięciu "Q"
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    confirmationMode = true;
                }
            }
        }
        else
        {
            Debug.LogError("Sprite is null. Make sure the Image component has a valid sprite.");
        }
    }
}

}
