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
        // Ukryj klawisz na pocz�tku gry
        klawisz.SetActive(false);

        // Ukryj panel ksi��ki na pocz�tku gry
        ksiazkaPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawd�, czy gracz wszed� do boxcollidera szafy
        if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Sprawd�, czy gracz opu�ci� boxcollider szafy
        if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && klawisz.activeSelf)
        {
            // Sprawd�, czy gracz jest wewn�trz boxcollidera stolu
            Collider2D collider2D = GetComponent<Collider2D>();
            Collider2D playerCollider = GameObject.FindGameObjectWithTag("Gracz").GetComponent<Collider2D>();

            if (collider2D.bounds.Intersects(playerCollider.bounds))
            {
                PokazKsiazke();
            }
        }

        // Sprawd�, czy gracz nacisn�� klawisz Esc, czy animacja ksiazki jest uruchomiona i ksiazka jest otwarta
        if (Input.GetKeyDown(KeyCode.Escape) && czyKsiazkaOtwarta)
        {
            ZamknijKsiazke();
        }
    }

    void PokazKsiazke()
    {
        // Odtw�rz animacj� otwierania szafki
        szafaAnimator.Play("otwieranie");

        // Odtw�rz animacj� naci�ni�cia klawisza
        klawiszAnimator.Play("nacisniecie");

        // Poka� panel ksi��ki
        ksiazkaPanel.SetActive(true);

        // Oznacz, �e ksi��ka jest otwarta
        czyKsiazkaOtwarta = true;
    }

    void ZamknijKsiazke()
    {
        // Ukryj panel ksi��ki
        ksiazkaPanel.SetActive(false);

        // Oznacz, �e ksi��ka jest zamkni�ta
        czyKsiazkaOtwarta = false;
    }
}