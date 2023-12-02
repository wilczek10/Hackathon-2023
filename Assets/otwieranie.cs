using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterakcjaZSzafaIKsiazka : MonoBehaviour
{
    public GameObject klawisz;
    public Animator szafaAnimator;
    public Animator klawiszAnimator;
    public GameObject ksiazkaPanel;

    private bool czyKsiazkaOtwarta = false;

    void Start()
    {
        // Ukryj klawisz na pocz¹tku gry
        klawisz.SetActive(false);

        // Ukryj panel ksi¹¿ki na pocz¹tku gry
        ksiazkaPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // SprawdŸ, czy gracz wszed³ do boxcollidera szafy
        if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // SprawdŸ, czy gracz opuœci³ boxcollider szafy
        if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && klawisz.activeSelf)
        {
            // SprawdŸ, czy gracz jest wewn¹trz boxcollidera stolu
            Collider2D collider2D = GetComponent<Collider2D>();
            Collider2D playerCollider = GameObject.FindGameObjectWithTag("Gracz").GetComponent<Collider2D>();

            if (collider2D.bounds.Intersects(playerCollider.bounds))
            {
                PokazKsiazke();
            }
        }

        // SprawdŸ, czy gracz nacisn¹³ klawisz Esc, czy animacja ksiazki jest uruchomiona i ksiazka jest otwarta
        if (Input.GetKeyDown(KeyCode.Escape) && czyKsiazkaOtwarta)
        {
            ZamknijKsiazke();
        }
    }

    void PokazKsiazke()
    {
        // Odtwórz animacjê otwierania szafki
        szafaAnimator.Play("otwieranie");

        // Odtwórz animacjê naciœniêcia klawisza
        klawiszAnimator.Play("nacisniecie");

        // Poka¿ panel ksi¹¿ki
        ksiazkaPanel.SetActive(true);

        // Oznacz, ¿e ksi¹¿ka jest otwarta
        czyKsiazkaOtwarta = true;
    }

    void ZamknijKsiazke()
    {
        // Ukryj panel ksi¹¿ki
        ksiazkaPanel.SetActive(false);

        // Oznacz, ¿e ksi¹¿ka jest zamkniêta
        czyKsiazkaOtwarta = false;
    }
}