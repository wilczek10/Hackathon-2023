using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private Animator animator;
    private bool shouldPlayAnimation = false;

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
            shouldPlayAnimation = true;

            // Ustaw boola w Animatorze
            animator.SetTrigger("Open");
        }
    }
}