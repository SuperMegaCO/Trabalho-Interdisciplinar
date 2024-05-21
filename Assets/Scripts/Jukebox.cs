using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jukebox : MonoBehaviour
{
    // Start is called before the first frame update
    int StartMenuID = 0;
    int LevelOneID = 1;
    int LevelTwoID = 2;
    void Start()
    {
        switch (this.gameObject.scene.name)
        {
            case "StartScreen":
                break;
            case "Level 1":
                AudioController.Instance.TocarBGMusic(LevelOneID);
                break;
        }
    }
    private void Awake()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
