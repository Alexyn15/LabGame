using UnityEngine;
using UnityEngine.UI;         

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Text gameOverScoreText;
    public GameObject gameOverText;
    public bool isGameOver = false;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }
        

//phuong thuc them score
public void AddScore(int score)
{
    this.score += score;
    scoreText.text = "Score: " + this.score;
}

public void GameOver()
{
    gameOverScoreText.text = "Your Score: " + this.score;
    gameOverText.SetActive(true);
    isGameOver = true;
}

    }



