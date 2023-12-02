using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterakcjaWinyl : MonoBehaviour
{
    public GameObject klawisz;
    public Animator klawiszAnimator;
    public GameObject winylPanel;
    public static bool Paused = false;

    private bool czyWinylOtwarty = false;

    void Start()
    {
        klawisz.SetActive(false);
        winylPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gracz"))
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
        if (Input.GetKeyDown(KeyCode.E) && klawisz.activeSelf)
        {
            Collider2D collider2D = GetComponent<Collider2D>();
            Collider2D playerCollider = GameObject.FindGameObjectWithTag("Gracz").GetComponent<Collider2D>();

            if (collider2D.bounds.Intersects(playerCollider.bounds))
            {
                PokazWinyl();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && czyWinylOtwarty)
        {
            ZamknijWinyl();
        }
    }

    void PokazWinyl()
    {
        klawiszAnimator.Play("nacisniete");
        winylPanel.SetActive(true);
        czyWinylOtwarty = true;
        Time.timeScale = 0f;
        Paused = true;
    }

    void ZamknijWinyl()
    {
        czyWinylOtwarty = false;
        winylPanel.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
}











