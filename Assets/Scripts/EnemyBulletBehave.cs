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
        movementvector = new Vector3(0f, 0f, -1 * speed * Time.deltaTime);
        transform.Translate(movementvector);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (Time.time - (PlayerMovement.timeLastHit + 1) >= 0))
        {
            other.transform.position = plane.transform.position + new Vector3(0f, 0, -3);
            GameManager.currentHP--;
            Destroy(this.gameObject);
            PlayerMovement.timeLastHit = Time.time;
        }
    }

}
