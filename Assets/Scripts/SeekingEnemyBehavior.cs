using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingEnemyBehavior : MonoBehaviour
{
        public Transform target; // alvo que eu quero seguir
        public float speed = 10;
        public EnemyTemplate Sword = new EnemyTemplate();
    private void Start()
    {
        Sword.HP = 3;
    }


    void Update()
        {
            Sword.invFrames--;
            Vector3 dirTarget = (transform.position - target.position); // direção entre o alvo e o player~

            dirTarget.y = 0f;

            dirTarget.Normalize(); // normalize a direcao para que o tamanho do vetor seja 1 mas a direcao e sentido se mantenham
        
            if (Vector3.Distance(target.position, transform.position) > 3f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            transform.rotation = Quaternion.LookRotation(new Vector3(-dirTarget.x,0,-dirTarget.z)); // faz o objeto olhar para a direcao que esta
            transform.Rotate(0,0,90);
        }
    private void OnTriggerEnter(Collider other)
    {
        if (Sword.invFrames <= 0)
        {
            if (other.CompareTag("AllyBullet"))
            {
                Sword.HP--;
                Destroy(other.gameObject);
                Sword.invFrames = 60;
            }
            if (Sword.HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}