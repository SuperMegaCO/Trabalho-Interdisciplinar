using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int points;
    public static int maxHP;
    public static int currentHP;
    public GameObject EndCanvas;
    public GameObject UICanvas;
    public Text pointsdisplay;
    public Text hpdisplay;
    public GameObject EnemyPrefab;
    GameObject[] EnemyArray= new GameObject[100];
    public int NumberOfEnemies;
    public Transform StartP;
    public Transform EndP;
    public Text HighScore;
    public GameObject Lifepowerup;
    void Start()
    {
        points = 0;
        maxHP = 3;
        currentHP = maxHP;
        Time.timeScale = 1.0f;
        EndCanvas.SetActive(false);
        InvokeRepeating("InstantiateEnemy", 5, 5);
        NumberOfEnemies = 1;
        InvokeRepeating("InstantiateLifeRestore", 3, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <1)
        {
            EndGame(EndCanvas);
        }
        pointsdisplay.text = "Points: " + points;
        hpdisplay.text = "HP: " + currentHP + "/" + maxHP;
    }
    public static void EnemyDestruction(GameObject enemy)
    {
        Destroy(enemy);
        points++;
    }
    public static void EndGame(GameObject canvas)
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
    }
    public void Restart()
    {

        points = 0;
        maxHP = 3;
        currentHP = maxHP;
        Time.timeScale = 1.0f;
        EndCanvas.SetActive(false);
        InvokeRepeating("InstantiateEnemy", 5, 5);
        NumberOfEnemies = 1;
        InvokeRepeating("InstantiateLifeRestore", 3, 10);
        SceneManager.LoadScene(0);
    }
    public void InstantiateEnemy()
    {

        GameObject EnemyInstance = Instantiate(EnemyPrefab);
        
        NumberOfEnemies++;
        EnemyInstance.name = "Enemy " + NumberOfEnemies;
        EnemyArray[NumberOfEnemies -1] = EnemyInstance;
        EnemyArray[NumberOfEnemies - 1].GetComponent<Enermy>().startMarker = StartP;
        EnemyArray[NumberOfEnemies - 1].GetComponent<Enermy>().endMarker = EndP;
        EnemyArray[NumberOfEnemies - 1].GetComponent<Enermy>().speed = Random.Range(3,25);


    }
    public void InstantiateLifeRestore()
    {
        Instantiate(Lifepowerup, new Vector3(StartP.position.x, StartP.position.y, (StartP.position.z - Random.Range(.5f, Vector3.Distance(StartP.position, EndP.position)))), Quaternion.identity);
    }
}
