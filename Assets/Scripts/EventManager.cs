using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public delegate void AddScore(int score);
    public AddScore addScore;

    public delegate void GameOver(bool gameOver);
    public GameOver gameOver;

    public delegate void ShakeCamera(float duration, float power);
    public ShakeCamera shakeCamera;

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

}
