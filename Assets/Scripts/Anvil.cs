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
    public int cooldowntracker = 0;
    
    int timesmoved = 0;
    bool movedmax = false;
    // Start is called before the first frame update
    void Start()
    {
        AnvilTemp.HP = 3;
        yplane = GameObject.Find("ActionPlane");
        AnvilTemp.Speed = 1;
    }
 

    // Update is called once per frame
    void Update()
    {
        AnvilTemp.invFrames--;
        cooldowntracker++;
        if (cooldowntracker % (3 * 60) == 0)
        {
            Attack();
        }
        if (timesmoved < 3 && movedmax == false)
        {
            transform.Translate(Vector3.back*AnvilTemp.Speed);
            timesmoved++;
        }
        else if (timesmoved >= 3 || (timesmoved > 0 && movedmax == true)) 
        {
            movedmax = true;
            transform.Translate(Vector3.forward * AnvilTemp.Speed);
            timesmoved--;
        }
        else if (timesmoved == 0)
        {
            movedmax = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AnvilTemp.invFrames <= 0)
        {
            if (other.CompareTag("AllyBullet"))
            {
                AnvilTemp.HP--;
                Destroy(other.gameObject);
                AnvilTemp.invFrames = 60;
            }
            if (AnvilTemp.HP <= 0)
            {
                Destroy(this.gameObject);
                Wave.aliveEnemies--;
            }
        }
    }
    public void Attack()
    {
        AttackExecute(6, AnvilComponent.transform.position, 1.0f);
    }
    //num = number of buillets, point is starting origin, radius is obvious
    // got part of this code from the internet, changed ti to make it spawn bullets in an arc
    public void AttackExecute(int num, Vector3 point, float radius)
    {

        for (int i = 0; i < num; i++)
        {

            /* Distance around the circle */
            var radians = (((2 * MathF.PI) / num) * i);
            /* Get the vector direction */
            var vertical = MathF.Sin(radians);
            var horizontal = MathF.Cos(radians);

            var spawnDir = new Vector3(horizontal, 0, vertical);

            /* Get the spawn position */
            var spawnPos = point - (spawnDir * radius); // Radius is just the distance away from the point

            /* Now spawn */
            var individualbullet = Instantiate(bullet, -spawnPos, Quaternion.identity) as GameObject;
            individualbullet.transform.LookAt(new Vector3(spawnDir.x, 0, spawnDir.z));

            /* Adjust height */
            individualbullet.transform.position = (new Vector3(spawnPos.x, yplane.transform.position.y, spawnPos.z));
        }
    }
}
