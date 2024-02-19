using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int bestGame = 0;
    private bool touch = false;
    public static GameManager Instance { get; private set; }
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    bool isGameOver = false;
    public List<GameObject> ObstaclePrefabs;

    public float obstacleInterval = 2;

    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    //public Vector2 yOffset = Vector2.zero;
    public float ObstacleMinY = -3;
    public float ObstacleMaxY = 3;
    public float ObstacleX = 5;
    public float ObstacleOrigin = 13;
    public float ObstacleSpeed = 2;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }
    public bool IsGameActive()
    {
        return !isGameOver;
    }
    public bool IsGameOVer()
    {
        return isGameOver;
    }
    public void endGame()
    {
        
        // termina o jogo
        isGameOver = true;
        if (score > bestGame)
        {
            bestGame = score;
        }
        Debug.Log("melhor pontuação " + bestGame);
        ReloadScene( 2);
        StartCoroutine(ReloadScene(2));
    }
    private int getHighscore()
    {
        return bestGame;
    }
    private IEnumerator ReloadScene(float delay)
    {
        int highscore = getHighscore();
        // esperar 2 segundos
        yield return new WaitForSeconds(delay);
        // recarregar a cena
        Debug.Log("reloading scene...");
        string SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
        Debug.Log("scene carregada...");
        bestGame = highscore; // ta saindo resetada  bestgame == 0
    }
}
