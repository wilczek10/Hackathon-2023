using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Singleton

    private int points = 0;

    // Singleton - Metoda do uzyskania dostêpu do obiektu GameManager
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        // Inicjalizacja obiektu GameManager w przypadku, gdy nie zosta³ jeszcze utworzony
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int GetPoints()
    {
        return points;
    }

    // Wywo³aj tê funkcjê, gdy gracz zdobywa punkty
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Aktualna liczba punktów: " + points);

        // SprawdŸ, czy zdobyto wystarczaj¹c¹ liczbê punktów
        if (points >= 3)
        {
            OnThreePointsReached();
            points = 0; // Zresetuj liczbê punktów po wywo³aniu funkcji
        }
    }

    // Ta funkcja zostanie wywo³ana, gdy zdobêdziesz 3 punkty
    private void OnThreePointsReached()
    {
        Debug.Log("Wywo³ano funkcjê po zdobyciu 3 punktów!");
        SceneManager.LoadScene("zakonczenie");
    }
}
