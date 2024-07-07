using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    public GameObject bullet;
    public GameObject yplane;
    public GameObject AnvilComponent;
    public EnemyTemplate AnvilTemp = new EnemyTemplate();
    public GameObject player;
    public int cooldowntracker = 2;
    public Vector3 firevector;
    public float timelastfired;
    int timesmoved = 0;
    bool movedmax = false;
    // Start is called before the first frame update
    void Start()
    {
        AnvilTemp.HP = 3;
        yplane = GameObject.Find("ActionPlane");
        AnvilTemp.Speed = -1f;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("ChangeDir", 4, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timesfired != 8) 
        {
            Attack(); 
        }
        transform.Translate(Vector3.forward * Time.deltaTime*AnvilTemp.Speed);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - (AnvilTemp.TimeLastHit + AnvilTemp.invFrames) >= 0)
        {
            if (other.CompareTag("AllyBullet"))
            {
                AnvilTemp.HP--;
                Destroy(other.gameObject);
                AnvilTemp.TimeLastHit = Time.deltaTime;
            }
            if (AnvilTemp.HP == 0)
            {
                Death();
                Destroy(this.gameObject);
                Wave.aliveEnemies--;
                GameManager.points++;
            }
        }
    }
    public int timesfired;
    public void Attack()
    {
        if (timesfired < 8)
        {
            Invoke("ShootBullet", .1f);
        }
        
        
    }
    public void ChangeDir()
    {
        AnvilTemp.Speed = AnvilTemp.Speed * -1f;
        timesfired = 0;
    }
    //num = number of buillets, point is starting origin, radius is obvious
    // got part of this code from the internet, changed ti to make it spawn bullets in an arc
   
    public GameObject particles;
    public GameObject particlesPrefab;
    public void Death()
    {
        particles = Instantiate(particlesPrefab, transform);
        Invoke("TurnOff", 1f);
    }
    public void TurnOff()
    {
        Destroy(particles);
    }
    public void ShootBullet()
    {
        GameObject bulletInst = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInst.transform.LookAt(player.transform.position);
        timesfired++;
    }
}
