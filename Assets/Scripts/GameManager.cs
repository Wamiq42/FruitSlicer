using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private bool isGameStarted = false;
    
    [SerializeField] private GameObject restartPanel;

    private float duration;
    private float power;


    /*
     * VARIABLES WITH GETTER SETTERS;
     */

    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
        }
    }

    
    public bool IsGameStarted
    {
        get => isGameStarted;
        set
        {
            isGameStarted = value;
        }
    }


    /*
     * FUNCTIONS
     */

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    private void Start()
    {
        EventManager.instance.addScore += UpdateScore;
        EventManager.instance.gameOver += GameOver;
    }
    private void OnDisable()
    {
        EventManager.instance.addScore -= UpdateScore;
        EventManager.instance.gameOver -= GameOver;
    }
    void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "Score : " + this.score;

    }
    void GameOver(bool gameOver)
    {
        // delegates for gameover setup
        //Time.timeScale = 0;
        IsGameStarted = false;
        restartPanel.SetActive(true);
    }
   
}
