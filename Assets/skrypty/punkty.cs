using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points = 0;

    // Wywo³aj tê funkcjê, gdy gracz zdobywa punkty
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Aktualna liczba punktów: " + points);

        // SprawdŸ, czy zdobyto wystarczaj¹c¹ liczbê punktów
        if (points >= 5)
        {
            OnFivePointsReached();
            points = 0; // Zresetuj liczbê punktów po wywo³aniu funkcji
        }
    }

    // Ta funkcja zostanie wywo³ana, gdy zdobêdziesz 5 punktów
    private void OnFivePointsReached()
    {
        Debug.Log("Wywo³ano funkcjê po zdobyciu 5 punktów!");
        // Tutaj umieœæ kod funkcji, któr¹ chcesz wywo³aæ
    }
}

