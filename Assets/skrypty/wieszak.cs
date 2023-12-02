using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wieszak : MonoBehaviour
{
    public GameObject klawisz;
    public Animator wieszakAnimator;
    public Animator klawiszAnimator;
    private GameManager gameManager;

    private bool szafaOtwarta = false;

    void Start()
    {
        // Ukryj klawisz na pocz�tku gry
        klawisz.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (szafaOtwarta == true)
        {
            klawisz.SetActive(false);
        }
        else if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && klawisz.activeSelf && !szafaOtwarta)
        {
            // Sprawd�, czy gracz jest wewn�trz boxcollidera szafy
            Collider2D collider2D = GetComponent<Collider2D>();
            Collider2D playerCollider = GameObject.FindGameObjectWithTag("Gracz").GetComponent<Collider2D>();

            Pokazwieszak();
        }
    }

    void Pokazwieszak()
    {

        gameManager.AddPoints(1);

        // Odtw�rz animacj� otwierania szafki
        wieszakAnimator.Play("bezczapki");

        // Odtw�rz animacj� naci�ni�cia klawisza
        klawiszAnimator.Play("nacisniecie");

        klawisz.SetActive(false);

        // Ustaw flag�, aby zablokowa� ponowne otwieranie szafy
        szafaOtwarta = true;
    }
}
