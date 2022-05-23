using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
public class LoadingScript : MonoBehaviour
{
    [SerializeField] private float waitTime;
     private GameObject spawner;
     private GameObject slicer;
    [SerializeField] private GameObject inGamePanel;
    

    private void OnEnable()
    {
        spawner = GameObject.Find("Spawner");
        slicer = GameObject.Find("Slicer");

        spawner.GetComponent<FruitSpawner>().enabled = true;
        slicer.GetComponent<Slicer2DController>().enabled = true;
        //spawner.SetActive(true);
        //slicer.SetActive(true);

        StartCoroutine(LoadingTime());
    }

    IEnumerator LoadingTime()
    {
        yield return new WaitForSeconds(waitTime);
        GameManager.instance.IsGameStarted = true;
        inGamePanel.SetActive(true);
        gameObject.SetActive(false);

    }
}
