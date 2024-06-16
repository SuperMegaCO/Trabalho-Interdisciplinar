using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CauldronBehavior : MonoBehaviour
{
    public GameObject bullet;
    public EnemyTemplate Cauldron = new EnemyTemplate();
    public float timeLastFired;
    // Start is called before the first frame update
    void Start()
    {
        Cauldron.HP = 3;

    }

    // Update is called once per frame
    void Update()
    {
        Cauldron.invFrames--;
        if (Time.time - (timeLastFired+1)>= 0)
        {
            Attack();
        }
    }
    void Attack()
    {
        float attackradius = 2;
        timeLastFired = Time.time;
        float[,] bulletpositions = { { 0, 1 }, { .707f, .707f }, { 1, 0 }, { 0, -1 }, { .707f, -.707f }, { -1, 0 }, { -.707f, -.707f }, { -.707f, .707f } };
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bullet, new Vector3(this.transform.position.x + bulletpositions[i,0], this.transform.position.y, this.transform.position.z + bulletpositions[i, 1]), Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Cauldron.invFrames <= 0)
        {
            if (other.CompareTag("AllyBullet"))
            {
                Cauldron.HP--;
                Destroy(other.gameObject);
                Cauldron.invFrames = 60;
            }
            if (Cauldron.HP <= 0)
            {
                Destroy(this.gameObject);
                Wave.aliveEnemies--;
            }
        }
    }
}
 
