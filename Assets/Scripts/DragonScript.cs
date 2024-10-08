using UnityEngine;
using UnityEngine.InputSystem;

public class DragonScript : MonoBehaviour
{
    public float flapStrength = 5f;
    public float outOfScreen = 17.5f;
    [HideInInspector] public PlayerInput playerInput;


    private Rigidbody2D rigidBody;
    private InputAction jumpAction;
    private LogicScript logic;
    private bool isAlive = true;

    private void Awake()
    {
        // Get the Rigidbody2D component
        rigidBody = GetComponent<Rigidbody2D>();

        // Get the PlayerInput component and the JumpAction
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];

        logic = FindFirstObjectByType<LogicScript>();
    }

    void gameOver()
    {
        logic.gameOver();
        isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space key (or jump action) is pressed
        if (jumpAction.triggered && isAlive)
        {
            rigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if ((transform.position.y < -outOfScreen) || (transform.position.y > outOfScreen))
        {
            gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            gameOver();
        }
    }
}
