
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public int level = 1; 
    public Ball ball { get; private set; }
    public Player player { get; private set; }
    public Tiles[] tiles { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    void Start()
    {
        NewGame();
    }

    void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void LoadLevel(int level)
    {
        this.level = level;
        
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.player = FindObjectOfType<Player>();
        this.tiles = FindObjectsOfType<Tiles>();
    }
    private void ResetLevel()
    {

        this.ball.ResetBall();
        this.player.ResetPlayer();
    }

    private void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Miss()
    {
        this.lives--;

        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
            Gameover();
        }

        Debug.Log("Missagain");
    }
    public void Hit(Tiles tiles)
    {
        this.score += tiles.points;

        if (Cleared())
        {
            LoadLevel(this.level + 1);
        }
    }
       bool Cleared()
    {
        Debug.Log("Loaded");
        for (int i = 0; i < this.tiles.Length; i++)
        {
            if (this.tiles[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
    
}
