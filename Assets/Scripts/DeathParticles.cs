using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particles;
    public GameObject particlesPrefab;
    public void Death()
    {
        particles = Instantiate(particlesPrefab, transform.parent);
        Invoke("TurnOff", .5f);
    }
    public void TurnOff()
    {
        Destroy(particles);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    
}
