using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls elements of the current stage
/// </summary>

public class Level : MonoBehaviour
{
    //Variables
    [Range(0, 10)] [SerializeField] float gameSpeed = 1f;
    [Range(0, 1)] [SerializeField] float winSlowMotion = .5f;

    int breakableBlocks = 0;
    int comboCount = 0;
    
    static int currentLayoutIndex = 0;
    public bool isPaused = false;

    public void LostLife(bool justLostLife) { lostALife = justLostLife; }
    static bool lostALife = false;


    //External Scripts
    SceneLoader sceneLoader;
    GameSession gameSession;

    [SerializeField] GameObject[] blockLayoutList;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
        Time.timeScale = gameSpeed;
        PickLayout();
        blockLayoutList[currentLayoutIndex].SetActive(true);
    }


   

    //Layout Functions
    public void PickLayout()
    {
        if (GameSession.levelCount <= blockLayoutList.Length) //if current stage lower than or equal to number of layout
        { currentLayoutIndex = GameSession.levelCount - 1; }
        else if (!lostALife)  { currentLayoutIndex = Random.Range(0, blockLayoutList.Length); }
    }


    //Combo Functions
    public int GetCombo() { return comboCount; }
    public void ComboIncrease()
    { 
        comboCount++;
        gameSession.UpdateHighCombo(comboCount);
    }
    public void ComboReset() { comboCount = 0; }


    //Block Functions
    public void AddBlock() { breakableBlocks++; }
    public void SubstractBlock() 
    {
        breakableBlocks--; 
        if (breakableBlocks <= 0) {
            FindObjectOfType<LoseCollider>().gameObject.SetActive(false);
            Time.timeScale *= winSlowMotion; 
            sceneLoader.NextLevel(); 
        }
    }


    //Pause System
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = gameSpeed;//unpause
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;//pause
            isPaused = true;
        }
    }


    //At the end of a scene
    private void OnDestroy() { Time.timeScale = 1; }
}
