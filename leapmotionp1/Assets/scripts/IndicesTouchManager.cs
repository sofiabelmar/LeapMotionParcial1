using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class IndicesTouchManager : MonoBehaviour
{
    [SerializeField]
    float PinchDistance;
    [SerializeField]
    float PalmDistance;
    [SerializeField]
    float ScaleMultiplier;

    [SerializeField]
    Transform lIndex;

    [SerializeField]
    Transform lThumb;
    
    [SerializeField]
    Transform rIndex;

    [SerializeField]
    Transform rThumb;
    [SerializeField]
    Transform rPalm;

    [SerializeField]
    Transform lPalm;

    bool PinchReady = false;

    bool creandoCubo = false;
    GameObject cube;

    [SerializeField]
    GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float handsDistance = (Vector3.Distance(lIndex.position,lThumb.position));

        if(lPalm.rotation.z >= 10)
        {

        }

        if (lPalm.transform.rotation.y >= 10)
        {
            Debug.Log("tESTAAA");
        }

        if(Vector3.Distance(lIndex.position,rIndex.position) <= PalmDistance)
        {
            PinchReady = true;
            Debug.Log(Vector3.Distance(lIndex.position,rIndex.position));
        }

        if(PinchReady)
        {
            if (Vector3.Distance(lIndex.position,lThumb.position) <= PinchDistance 
            && Vector3.Distance(rIndex.position,rThumb.position) <= PinchDistance 
            && creandoCubo == false)
            {
                cube = Instantiate(obj, new Vector3(lPalm.position.x + (Vector3.Distance(lPalm.position,rPalm.position)/2),lPalm.position.y,lPalm.position.z),Quaternion.identity);
                creandoCubo = true;
            }
        }

        if(creandoCubo)
        {
            cube.transform.position = 
                new Vector3(
                    (lIndex.position.x + rIndex.position.x) / 2, 
                    (lIndex.position.y + rIndex.position.y) / 2, 
                    (lIndex.position.z + rIndex.position.z) / 2);

            cube.transform.localScale = new Vector3(
                Vector3.Distance(lIndex.position,rIndex.position) * ScaleMultiplier, 
                Vector3.Distance(lIndex.position,rIndex.position) * ScaleMultiplier, 
                Vector3.Distance(lIndex.position,rIndex.position) * ScaleMultiplier);

            cube.transform.rotation = Quaternion.identity;
        }

        if(Vector3.Distance(lIndex.position,lThumb.position) >= PinchDistance || Vector3.Distance(rIndex.position,rThumb.position) >= PinchDistance)
        {
            creandoCubo = false;
            PinchReady = false;
        }
    }
}