using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{
    int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.currentHP < GameManager.maxHP)
        {
            GameManager.currentHP++;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
  
    }
}
