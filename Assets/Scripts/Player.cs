using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 10;
    public GameObject plane;
    public GameObject ActionPlane;
    float x;
    float z;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject bullet;
    float cooldownstart = 0;
    void Start()
    {
  
        transform.position = plane.transform.position + new Vector3(-3, ActionPlane.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float sizex = (plane.GetComponent<MeshRenderer>().bounds.size.x/2);
        float sizez = (plane.GetComponent<MeshRenderer>().bounds.size.z/2);
        float maxx = plane.transform.position.x + sizex -.7f;
        float minx = plane.transform.position.x - sizex +.7f;
        float maxz = plane.transform.position.z + sizez - .7f;
        float minz = plane.transform.position.z - sizez + .7f;
        float movementx = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        bool withinboundsx = ((movementx + transform.position.x) < maxx) && ((movementx + transform.position.x) > minx);
        float movementz = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        bool withinboundsz = ((movementz + transform.position.z) < maxz) && ((movementz + transform.position.z) > minz);
        if (withinboundsx && withinboundsz) 
        {
            x = Input.GetAxis("Vertical");
            z = -Input.GetAxis("Horizontal");
            Vector3 movement = (new Vector3(x, 0f, z));
            transform.Translate(movement.normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && (Time.time - cooldownstart  > .5))
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
}
