using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    static int speed = 10;
    public GameObject plane;
    public GameObject ActionPlane;
    float x;
    float z;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject bullet;
    public static bool invFrames;
    public static float timeLastHit;
    Vector3 StartPos;
    public ParticleSystem bulletcleareffect;
    public GameObject hit;
    float cooldownstart;
    void Start()
    {
        timeLastHit = -1;
        transform.position = plane.transform.position + new Vector3(0f, ActionPlane.transform.position.y, -3);
        StartPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Collider>().transform.localScale = Vector3.one * .3f;
            speed = 3;
        }
        else
        {
            speed = 10;
            GetComponent<Collider>().transform.localScale = Vector3.one;
        }
       ;
        float sizex = (plane.GetComponent<MeshRenderer>().bounds.size.x / 2);
        float sizez = (plane.GetComponent<MeshRenderer>().bounds.size.z / 2);
        float maxx = plane.transform.position.x + sizex - .7f;
        float minx = plane.transform.position.x - sizex + .7f;
        float maxz = plane.transform.position.z + sizez - .7f;
        float minz = plane.transform.position.z - sizez + .7f;
        float movementx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        bool withinboundsx = ((movementx + transform.position.x) < maxx) && ((movementx + transform.position.x) > minx);
        float movementz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        bool withinboundsz = ((movementz + transform.position.z) < maxz) && ((movementz + transform.position.z) > minz);
        if (withinboundsx && withinboundsz)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 movement = (new Vector3(x, 0f, z));
            transform.Translate(movement.normalized * speed * Time.deltaTime);
        }
        if ((Time.time - cooldownstart > .2))
        {
            cooldownstart = Time.time;
            Attack(gun1, gun2, bullet);
        }
 

    }
    void Attack(GameObject gun, GameObject gun2, GameObject bullet)
    {
        Vector3 initialposition1 = gun.transform.position;
        Vector3 initialposition2 = gun2.transform.position;
        Instantiate(bullet, initialposition1, Quaternion.identity);
        Instantiate(bullet, initialposition2, Quaternion.identity);

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Bullet")) && (Time.time - (timeLastHit + 1) >= 0))
        {
            HitActive();
            GameManager.currentHP--;
            timeLastHit = Time.time;
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
            {
                Vector3 particlepos = bullet.transform.position;
                Destroy(bullet);
                Instantiate(bulletcleareffect, particlepos, Quaternion.Euler(90, 0, 0));
                transform.position = StartPos;
                
                
            }
            
        }
        else if (other.CompareTag("Bullet"))
        {
        }
    }


    public void HitActive()
    {
        hit.SetActive(true);
        Invoke("HitInactive", .5f);
    }
    public void HitInactive()
    {
        hit.SetActive(false);
    }
}
