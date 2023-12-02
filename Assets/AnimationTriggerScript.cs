using UnityEngine;

public class AnimationTriggerScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for the trigger condition (e.g., Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the animation
            animator.SetTrigger("YourTriggerName");
        }
    }
}
