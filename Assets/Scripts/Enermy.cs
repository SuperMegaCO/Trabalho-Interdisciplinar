using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startMarker;
    public Transform endMarker;
    public GameObject gun;
    public GameObject bullet;
    // Movement speed in units per second.
    public float speed = 4.0F;

    // Time when the movement started.
    private float startTime;
    private float cooldownTime;
    private float lastUsedTime = 0;

    // Total distance between the markers.
    private float journeyLength;
    void Start()
    {

        transform.position = new Vector3(0f, GameObject.Find("ActionPlane").transform.position.y, 0f);
        // Keep a note of the time the movement started.
        startTime = Time.time;
        cooldownTime = 1;
        

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Attack(gun, bullet);
        if (transform.position == endMarker.position)
        {
            Transform temp = endMarker;
            endMarker = startMarker;
            startMarker = temp;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }
    }
    void EnemyMove()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
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
}
