using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBulletBehave : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 5;
    Vector3 movementvector;
    float TimeStart;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementvector = new Vector3(0f, 0f, 1 * speed * Time.deltaTime);
        transform.Translate(movementvector);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.EnemyDestruction(other.gameObject);
        }
    }
    
}
