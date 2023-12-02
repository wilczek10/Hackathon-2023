using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interakcja : MonoBehaviour
{
    public GameObject klawisz;
    public Animator szafaAnimator;
    public Animator klawiszAnimator;
    public string animationName;

    protected GameManager gameManager;
    protected bool otwarte = false;
    protected static Interakcja currentInteraction;

    void Start()
    {
        // Ukryj klawisz na pocz¹tku gry
        klawisz.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (otwarte == true)
        {
            klawisz.SetActive(false);
        }
        else if (other.CompareTag("Gracz"))
        {
            klawisz.SetActive(true);
            currentInteraction = this;
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
        if (Input.GetKeyDown(KeyCode.E) && klawisz.activeSelf && !otwarte && currentInteraction == this)
        {
            // SprawdŸ, czy gracz jest wewn¹trz boxcollidera szafy
            Collider2D collider2D = GetComponent<Collider2D>();
            Collider2D playerCollider = GameObject.FindGameObjectWithTag("Gracz").GetComponent<Collider2D>();

            Pokaz();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && otwarte && currentInteraction == this)
        {
            Zamknij();
        }
    }

    void Pokaz()
    {
        gameManager.AddPoints(1);

        // Odtwórz animacjê otwierania szafki
        if (szafaAnimator)
        {
            szafaAnimator.Play(animationName);
        }

        // Odtwórz animacjê naciœniêcia klawisza
        klawiszAnimator.Play("nacisniecie");

        klawisz.SetActive(false);

        Otworz();

        // Ustaw flagê, aby zablokowaæ ponowne otwieranie szafy
        otwarte = true;
    }

    protected virtual void Otworz()
    {

    }

    protected virtual void Zamknij()
    {

    }
}
