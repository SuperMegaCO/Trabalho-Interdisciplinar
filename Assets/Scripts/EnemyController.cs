using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int[] WaveHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AllyBullet"))
        {
            GameManager.EnemyDestruction(this.gameObject);
        }
    }
}

public class EnemyTemplate
{
    public int HP;
    public  float Speed;
    public GameObject me;
    public Animation damageanim;
    public Animation deathanim;
    public float TimeLastHit = 0;
    public float TimeSinceLastHit = 2;
    public float TimeLastShot = 0;
    public float ShootCoolDown = .5f;
    public float invFrames = 1f;
    public int waveID;
    public void OnDie(GameObject me, int[] Wave)
    {
        Wave[waveID]--;
        GameManager.points++;
        GameObject.Destroy(me);
    }

}
