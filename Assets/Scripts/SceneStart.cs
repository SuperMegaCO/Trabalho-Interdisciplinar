using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (GameManager.GetComponent<GameManager>().isActiveAndEnabled != true)
        {
            GameManager.GetComponent<GameManager>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
