using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszaniePostaci : MonoBehaviour
{
    public float predkosc = 2f; // Ustaw prędkość poruszania postaci
    private bool idzieWLewo = true; // Flaga określająca kierunek ruchu

    void Update()
    {
        // Poruszanie w lewo i prawo
        float ruch = 0;

        if (idzieWLewo)
        {
            ruch = -predkosc * Time.deltaTime;
        }
        else
        {
            ruch = predkosc * Time.deltaTime;
        }

        transform.Translate(new Vector3(ruch, 0, 0));

        // Zmiana kierunku po osiągnięciu pewnej odległości
        if (Mathf.Abs(transform.position.x) > 2.0f)
        {
            idzieWLewo = !idzieWLewo;
        }
    }
}

