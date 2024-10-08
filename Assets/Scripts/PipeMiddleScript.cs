using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private LogicScript logic;

    void Awake()
    {
        logic = FindFirstObjectByType<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            logic.addScore();
        }
    }
}
