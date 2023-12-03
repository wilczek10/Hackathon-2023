using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject tabelka;

    private Animator animator;
    

    private int counter = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Sprawdzaj, czy naciśnięto klawisz "E"
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Ustaw boola na true, aby uruchomić animację
            

            // Ustaw boola w Animatorze
            animator.SetTrigger("Open");

            counter++;
            if(counter == 2){
                tabelka.SetActive(true);
            }
        }
    }
}