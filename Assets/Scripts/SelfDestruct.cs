using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float yAxis = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -yAxis)
        {
            Destroy(gameObject);
        }
    }
}
