
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public int level = 1; 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        NewGame();
    }

    void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        LoadLevel(1);
    }
    void LoadLevel(int level)
    {
        this.level = level;
        
        SceneManager.LoadScene(level);
    }
}
