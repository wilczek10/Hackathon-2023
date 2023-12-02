using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Singleton

    private int points = 0;

    // Singleton - Metoda do uzyskania dost�pu do obiektu GameManager
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
        // Inicjalizacja obiektu GameManager w przypadku, gdy nie zosta� jeszcze utworzony
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

    // Wywo�aj t� funkcj�, gdy gracz zdobywa punkty
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Aktualna liczba punkt�w: " + points);

        // Sprawd�, czy zdobyto wystarczaj�c� liczb� punkt�w
        if (points >= 3)
        {
            OnThreePointsReached();
            points = 0; // Zresetuj liczb� punkt�w po wywo�aniu funkcji
        }
    }

    // Ta funkcja zostanie wywo�ana, gdy zdob�dziesz 3 punkty
    private void OnThreePointsReached()
    {
        Debug.Log("Wywo�ano funkcj� po zdobyciu 3 punkt�w!");
        SceneManager.LoadScene("zakonczenie");
    }
}
