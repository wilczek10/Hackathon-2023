using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public Animator drzwiAnimator;


    private int points = 0;

    // Wywo�aj t� funkcj�, gdy gracz zdobywa punkty
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Aktualna liczba punkt�w: " + points);

        // Sprawd�, czy zdobyto wystarczaj�c� liczb� punkt�w
        if (points >= 3)
        {
            OnFivePointsReached();
            points = 0; // Zresetuj liczb� punkt�w po wywo�aniu funkcji
        }
    }

    // Ta funkcja zostanie wywo�ana, gdy zdob�dziesz 5 punkt�w
    private void OnFivePointsReached()
    {
        drzwiAnimator.Play("otwieranie");
        Debug.Log("Wywo�ano funkcj� po zdobyciu 3 punkty!");
        // Tutaj umie�� kod funkcji, kt�r� chcesz wywo�a�
    }
}

