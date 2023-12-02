using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wieszak : MonoBehaviour
{
    public GameObject klawisz;
    public Animator szafaAnimator;
    public Animator klawiszAnimator;

    private bool czyKsiazkaOtwarta = false;

    void Start()
    {
        // Ukryj klawisz na pocz¹tku gry
        klawisz.SetActive(false);
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
        szafaAnimator.Play("bez");

        // Odtwórz animacjê naciœniêcia klawisza
        klawiszAnimator.Play("Nacisnij");

        // Oznacz, ¿e ksi¹¿ka jest otwarta
        czyKsiazkaOtwarta = true;
    }

    void ZamknijKsiazke()
    {

        // Oznacz, ¿e ksi¹¿ka jest zamkniêta
        czyKsiazkaOtwarta = false;
    }
}