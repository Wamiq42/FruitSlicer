using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{


    [SerializeField]private GameObject currentPanel;


    

    public void OnClick(GameObject nextPanel)
    {
        if (Time.timeScale == 0 )
        {
            Time.timeScale = 1;
        }
        nextPanel.SetActive(true);
        currentPanel.SetActive(false);
    }
    public void RestartGame()
    {
        EventManager.instance.addScore?.Invoke(-GameManager.instance.Score);
        SceneManager.LoadScene(0);

    }

}
