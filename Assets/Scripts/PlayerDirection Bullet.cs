using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class PlayerDirectionBullet : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 5;
    public GameObject plane;
    Vector3 movementvector;
    Vector3 dirTarget;
    float TimeStart;

    void Start()
    {
        plane = GameObject.Find("ActionPlane");
        dirTarget = (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position); // direção entre o alvo e o player~
        transform.rotation = Quaternion.LookRotation(new Vector3(dirTarget.x, 0, dirTarget.z)); // faz o objeto olhar para a direcao que est
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
            other.transform.position = plane.transform.position + new Vector3(0f, 0, -3);
            GameManager.currentHP--;
        }
    }
}
