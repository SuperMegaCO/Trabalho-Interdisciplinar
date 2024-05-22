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
    public GameObject PauseCanvas;
    public Text pointsdisplay;
    public Text hpdisplay;
    public GameObject EnemyPrefab;
    GameObject[] EnemyArray= new GameObject[100];
    public int NumberOfEnemies;
    public Transform StartP;
    public Transform EndP;
    public Text HighScore;
    public GameObject Lifepowerup;
    public GameObject GameOver;
    public GameObject Win;
    public bool paused = false;
    void Awake()
    {
        AudioController.Instance.TocarBGMusic(1);
        points = 0;
        maxHP = 3;
        currentHP = maxHP;
        Time.timeScale = 1.0f;
        EndCanvas.SetActive(false);
        InvokeRepeating("InstantiateEnemy", 0, 1);
        NumberOfEnemies = 1;
        InvokeRepeating("InstantiateLifeRestore", 3, 10);

    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 0)
        {
            EndGame(EndCanvas,GameOver);
        }
        if (points > 5)
        {
            EndGame(EndCanvas, Win);    
        }
        pointsdisplay.text = "Points: " + points;
        hpdisplay.text = "HP: " + currentHP + "/" + maxHP;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = Pause(paused);
        }
    }
    public static void EnemyDestruction(GameObject enemy)
    {
        Destroy(enemy);
        points++;
    }
    public static void EndGame(GameObject canvas, GameObject Panel)
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
        Panel.SetActive(true);
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



    }
    public bool Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 1.0f;  
            
            UICanvas.SetActive(true);
            PauseCanvas.SetActive(false);
            return !pause;
        }
        else 
        {
            Time.timeScale = 0f;
            
            UICanvas.SetActive(false);
            PauseCanvas.SetActive(true);
            return !pause;
        }

    }
    public void InstantiateLifeRestore()
    {
        Instantiate(Lifepowerup, new Vector3(StartP.position.x + 10 + Random.Range(.5f, Vector3.Distance(StartP.position, EndP.position)), StartP.position.y, StartP.position.z), Quaternion.identity);
    }
}
