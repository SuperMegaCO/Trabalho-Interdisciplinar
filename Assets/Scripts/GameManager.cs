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
    public Text wavedisplay;
    public GameObject HealthDisplay;
    public Sprite[] Health = new Sprite[3];
    public Text pointsdisplay;
    public static bool gameWon = false;

    public Text HighScore;
    public GameObject Lifepowerup;
    public GameObject GameOver;
    public GameObject Win;
    public GameObject deathEffect;
    public bool paused = false;
    void Awake()
    {
        //AudioController.Instance.TocarBGMusic(1);
        points = 0;
        maxHP = 3;
        gameWon = false;
        currentHP = maxHP;
        Time.timeScale = 1.0f;
        EndCanvas.SetActive(false);

    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            EndGame(EndCanvas, GameOver);
        }
        if (gameWon)
        {
            EndGame(EndCanvas, Win);    
        }
        wavedisplay.text = "Enemies Left Until Next Wave: " + Wave.aliveEnemies + "/" + Wave.numbOfEnemies;
        pointsdisplay.text = "Points: " + points;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = Pause(paused);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameWon = true;
        }
        HealthDisplay.GetComponent<Image>().sprite = Health[System.Math.Clamp(currentHP - 1, 0, 2)];
       
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
        InvokeRepeating("InstantiateLifeRestore", 3, 10);
        SceneManager.LoadScene(0);
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
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(2);
    }
    
}
