using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        transform.position = new Vector3(0f, GameObject.Find("ActionPlane").transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
