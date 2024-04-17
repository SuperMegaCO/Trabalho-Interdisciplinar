using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehave : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 5;
    public GameObject plane;
    Vector3 movementvector;
    float TimeStart;

    void Start()
    {
        plane = GameObject.Find("ActionPlane");
    }

    // Update is called once per frame
    void Update()
    {
        movementvector = new Vector3(-1 * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(movementvector);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = plane.transform.position + new Vector3(-3, 0, 0); ;
            GameManager.currentHP--;
        }
    }

}
