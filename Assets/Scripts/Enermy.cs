using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gun;
    public GameObject bullet;
    // Movement speed in units per second.
     Vector3 direcao = Vector3.left;
    public float speed = 6f;
    GameObject plane;
    float posParaInverter;
    public Transform planeTransform;

    public bool inverteu;

    // Time when the movement started.

    private float cooldownTime = 3;
    private float lastUsedTime = 0;

    void Start()
    {
        plane = GameObject.Find("ActionPlane");
        transform.position = new Vector3((GameObject.Find("LeftSpawnPoint").transform.position.x+15f), GameObject.Find("ActionPlane").transform.position.y, GameObject.Find("LeftSpawnPoint").transform.position.z);
        cooldownTime = 1;
        planeTransform = GameObject.Find("ActionPlane").transform;
        posParaInverter = GameObject.Find("PointZigzag").transform.position.x;
    }
    private void Awake()
    {
        posParaInverter = GameObject.Find("PointZigzag").transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Attack(gun, bullet);
        ZigZag();
    }
    void EnemyMove()
    {

    }
    void Attack(GameObject gun, GameObject bullet)
    {
        if ((Time.time > cooldownTime + lastUsedTime) )
        {
            Vector3 initialposition1 = gun.transform.position;
            Instantiate(bullet, initialposition1, Quaternion.identity);
            lastUsedTime = Time.time;
        }
    }
    public void ZigZag()
    {
        transform.Translate(direcao * speed * Time.deltaTime);
        if (transform.position.x > (planeTransform.position.x + posParaInverter))
        {
            inverteu = true;
            direcao = direcao * -1f;
        }
        if (transform.position.x < (planeTransform.position.x - posParaInverter))
        {
            inverteu = true;
            direcao = direcao * -1f;
        }


    }
}
