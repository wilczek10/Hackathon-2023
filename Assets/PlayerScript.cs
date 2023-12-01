using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// The speed of the ship
    /// </summary>
    public float speed = 20f;

    /// <summary>
    /// Store the horizontal movement
    /// </summary>
    private float horizontalMovement;

    /// <summary>
    /// Store the vertical movement
    /// </summary>
    private float verticalMovement;

    void Update()
    {
        // Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Update horizontal movement
        horizontalMovement = speed * inputX;

        // Update vertical movement
        verticalMovement = speed * inputY;

        // Optional: To slow down the movement when not pressing any keys
        if (inputX == 0)
        {
            horizontalMovement = 0f;
        }

        if (inputY == 0)
        {
            verticalMovement = 0f;
        }

        // Flip the sprite based on the horizontal movement
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        // Move the game object
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMovement, verticalMovement);
    }
}
