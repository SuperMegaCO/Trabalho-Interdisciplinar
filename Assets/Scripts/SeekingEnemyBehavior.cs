using UnityEngine;

public class SeekingEnemyBehavior : MonoBehaviour
{
    public Transform target; // alvo que eu quero seguir
    public float speed = 100;
    public EnemyTemplate Sword = new EnemyTemplate();
    public Animation damageAnim;
    public Animation deathAnim;
    float startTime;
    public GameObject spawnFX;
    Vector3 dirTarget;
    private void Start()
    {
        Sword.HP = 3;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dirTarget = (transform.position - target.position); // direção entre o alvo e o player~
        transform.rotation = Quaternion.LookRotation(new Vector3(-dirTarget.x, 0, -dirTarget.z)); // faz o objeto olhar para a direcao que est
        startTime = Time.time;
    }


    void Update()
    {
        Sword.invFrames--;
        

        dirTarget.y = 0f;
        dirTarget.x = 0f;

        dirTarget.Normalize(); // normalize a direcao para que o tamanho do vetor seja 1 mas a direcao e sentido se mantenham

        if (Vector3.Distance(target.position, transform.position) > 1f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Time.time - startTime > 5)
        {
            Destroy(this.gameObject);
            Wave.aliveEnemies--;
        }
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
                Wave.aliveEnemies--;
            }
        }
    }
}