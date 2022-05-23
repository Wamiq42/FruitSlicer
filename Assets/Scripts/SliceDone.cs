using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
using Utilities2D;
public class SliceDone : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void Start()
    {
        Sliceable2D slicer = GetComponent<Sliceable2D>();
        slicer.AddResultEvent(AfterSlice);
    }

    void AfterSlice(Slice2D slice)
    {
        
        if (gameObject.name.Contains("bomb"))
        {
            //UnityEngine.Debug.Log("got Bomb Objects");
            EventManager.instance.shakeCamera?.Invoke(0.5f, 1.0f);
            EventManager.instance.gameOver?.Invoke(true);
            
        }
        else
        {
            //UnityEngine.Debug.Log("got Cutted Objects");
            EventManager.instance.addScore?.Invoke(10);
            foreach (GameObject slicedObj in slice.GetGameObjects())
            {
                
                Polygon2D polygon2D = new Polygon2D();


                Rigidbody2D slicedRigidbody = slicedObj.GetComponent<Rigidbody2D>();
                slicedRigidbody.AddForce(new Vector2(Random.Range(-300, 300), Random.Range(-300, 300)));
                slicedRigidbody.AddTorque(Random.Range(-150, 150));




                Sliceable2D slicer = slicedObj.GetComponent<Sliceable2D>();
                slicer.enabled = false;

                slicedObj.gameObject.AddComponent<DestroySlices>();
            }
        }
       
    }
}
