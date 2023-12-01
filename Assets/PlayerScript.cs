using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public float speed = 20f; // Changed to a single speed value

    /// <summary>
    /// 2 - Store the movement
    /// </summary>
    private float movement;

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");

        // 4 - Movement per direction
        movement = speed * inputX;

        // Optional: To slow down the movement when not pressing any keys
        if (inputX == 0)
        {
            movement = 0f;
        }
    }

    void FixedUpdate()
    {
        // 5 - Move the game object
        GetComponent<Rigidbody2D>().velocity = new Vector2(movement, GetComponent<Rigidbody2D>().velocity.y);
    }
}
   