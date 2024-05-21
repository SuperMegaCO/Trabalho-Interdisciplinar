using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public int LevelSelect = 0;
    void Start()
    {
        AudioController.Instance.TocarBGMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelOne()
    {
        LevelSelect = 1;
    }
    public void LevelTwo()
    {
        LevelSelect = 2;
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(1);
    }
    public void StartGameFromSelect()
    {
        SceneManager.LoadScene($"Level {LevelSelect}", LoadSceneMode.Single);
        AudioController.Instance.TocarBGMusic(1);
    }
    
        
    

}
