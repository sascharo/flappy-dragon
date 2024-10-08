using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSFX;
    public AudioSource gameOverSFX;

    private DragonScript dragon;
    private PlayerInput playerInput;
    private InputAction cancelAction;

    private void Awake()
    {
        dragon = FindFirstObjectByType<DragonScript>();
    }

    private void Start()
    {
        playerInput = dragon.playerInput;
        cancelAction = playerInput.actions["Cancel"];
    }

    void Update()
    {
        // Check if space key (or jump action) is pressed
        if (cancelAction.triggered)
        {
            Application.Quit();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSFX.Play();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverSFX.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
