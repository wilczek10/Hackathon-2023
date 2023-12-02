using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VinylPuzzleSolver : MonoBehaviour
{
    public Text questionText;
    public UnityEngine.Object[] vinylOptions;
    private int correctVinylIndex = 3; // Indeks poprawnego winyla (indeksy zaczynają się od 0)
    private int selectedVinylIndex = -1; // Indeks zaznaczonego winyla (-1 oznacza, że nie wybrano jeszcze żadnego)

    void Start()
    {
        AskQuestion();
    }

    void Update()
    {
        if (selectedVinylIndex != -1 && Input.GetKeyDown(KeyCode.R))
        {
            CheckAnswer();
        }
    }

    void AskQuestion()
    {
        if (vinylOptions.Length > 0 && questionText != null)
        {
            selectedVinylIndex = -1;
            questionText.text = "Czy to ten?";
        }
    }

    public void OnRightButtonClicked()
    {
        selectedVinylIndex = (selectedVinylIndex + 1) % vinylOptions.Length;
        AskQuestion();
    }

    public void OnLeftButtonClicked()
    {
        selectedVinylIndex = (selectedVinylIndex - 1 + vinylOptions.Length) % vinylOptions.Length;
        AskQuestion();
    }

    void CheckAnswer()
    {
        if (selectedVinylIndex == correctVinylIndex)
        {
            Debug.Log("Dobrze!");
        }
        else
        {
            Debug.Log("Źle!");
        }
    }
}
