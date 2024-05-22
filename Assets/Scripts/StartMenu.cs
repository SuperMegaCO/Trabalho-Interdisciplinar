using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public int LevelSelect = 0;
    public Canvas StartScreen;
    public Canvas LevelScreen;
    public Canvas PauseScreen;
    void Start()
    {
        AudioController.Instance.TocarBGMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(1);
    }
    public void StartGameFromSelectOne()
    {
        SceneManager.LoadScene($"Level 1", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(1);
    }
    public void StartGameFromSelectTwo()
    {
        SceneManager.LoadScene($"Level 2", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(2);
    }
    public void StartGameFromSelectThree()
    {
        SceneManager.LoadScene($"Level 3", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GoToLvlSelect()
    {
        StartScreen.gameObject.SetActive(false); 
        LevelScreen.gameObject.SetActive(true);
    }
    public void GoToStart()
    {
        StartScreen.gameObject.SetActive(true);
        LevelScreen.gameObject.SetActive(false);
    }
    public void GoToPause()
    {
        StartScreen.gameObject.SetActive(true);
        LevelScreen.gameObject.SetActive(false);
    }




}
