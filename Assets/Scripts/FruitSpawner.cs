using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruits;
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 1f;

    [SerializeField] private float speed = 10f;

    private void Start()
    {
        //fruits = new List<GameObject>();
        SettingGameObjectsInList();
        StartCoroutine("SpawnFruits");
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            if (GameManager.instance.IsGameStarted)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[spawnIndex];

                int fruitIndex = Random.Range(0, fruits.Count);


                GameObject temp = Instantiate(fruits[fruitIndex], spawnPoint.position, spawnPoint.rotation);
                temp.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            }
            
        }
    }
    void SettingGameObjectsInList()
    {
        fruits = new List<GameObject>();

        foreach (var item in Resources.LoadAll<GameObject>("FruitPrefabs"))
        {
            fruits.Add(item);
        }
    }

}
