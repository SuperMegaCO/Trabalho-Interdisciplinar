using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            speed *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementvector = new Vector3(0f, 0f, -1 * speed * Time.deltaTime);
        transform.Translate(movementvector);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
        }


    }

}
