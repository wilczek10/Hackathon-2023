using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageWithButtons : MonoBehaviour
{
    public Image imageToChange;
    public Sprite[] imageOptions;
    private int currentImageIndex = 0;

    void Start()
    {
        UpdateImage();
    }

    public void OnRightButtonClicked()
    {
        // Zmniejsz indeks obrazka (jeœli to mo¿liwe)
        currentImageIndex = (currentImageIndex + 1) % imageOptions.Length;
        UpdateImage();
    }

    public void OnLeftButtonClicked()
    {
        // Zmniejsz indeks obrazka (jeœli to mo¿liwe)
        currentImageIndex = (currentImageIndex - 1 + imageOptions.Length) % imageOptions.Length;
        UpdateImage();
    }

    void UpdateImage()
    {
        // Ustaw nowy obrazek na podstawie aktualnego indeksu
        if (imageOptions.Length > 0 && imageToChange != null)
        {
            imageToChange.sprite = imageOptions[currentImageIndex];
        }
    }
}

