using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBulletBehave : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 5;
    Vector3 movementvector;

    void Start()
    {
        movementvector = new Vector3(1 * speed * Time.deltaTime,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {

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
