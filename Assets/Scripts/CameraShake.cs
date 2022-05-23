using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   
    private float duration;
    private float power;
    private float shakeFadeTime;
    private float rotation;
    [SerializeField] private float rotationMultipler;
    private new Vector3 orignalPosition;
    private void Start()
    {
        EventManager.instance.shakeCamera += StartShake;
        orignalPosition = transform.position;
    }
    private void OnDisable()
    {
        EventManager.instance.shakeCamera += StartShake;
    }

    private void LateUpdate()
    {
        Shaking();
    }
    void StartShake(float duration, float power)
    {
        Debug.Log("started Shake");

        this.duration = duration;
        this.power = power;

        shakeFadeTime = power / duration;
        rotation = power * rotationMultipler;
      
    }
    void Shaking()
    {
        if (duration > 0.0f)
        {
            Debug.Log("Shaking");
            duration -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * power;
            float yAmount = Random.Range(-1f, 1f) * power;

            transform.position += new Vector3(xAmount, yAmount, 0);
            power = Mathf.MoveTowards(power, 0, shakeFadeTime * Time.deltaTime);
            rotation = Mathf.MoveTowards(rotation, 0, shakeFadeTime * rotationMultipler* Time.deltaTime);
        }
        //transform.position = orignalPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation * Random.Range(-1, 1));
    }

}
