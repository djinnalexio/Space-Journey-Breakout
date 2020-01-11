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

    public int breakableBlocks = 0;
    int comboCount = 0;
    
    static int currentLayoutIndex = 0;
    public bool pauseOn = false;

    public void LostLife(bool justLostLife) { lostALife = justLostLife; }
    static bool lostALife = false;


    //External Scripts
    SceneLoader sceneLoader;
    GameSession gameSession;

    [SerializeField] GameObject[] blockLayoutList;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Time.timeScale = gameSpeed;
        PickLayout();
        blockLayoutList[currentLayoutIndex].SetActive(true);
    }

    public void PickLayout()
    {
        if (gameSession.GetLevelCount() <= blockLayoutList.Length) //if current stage lower than or equal to number of layout
        { currentLayoutIndex = gameSession.GetLevelCount() - 1; }
        else if (!lostALife)  { currentLayoutIndex = UnityEngine.Random.Range(0, blockLayoutList.Length); }
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
    public void BlockDestroyed() 
    {
        breakableBlocks--; 
        if (breakableBlocks <= 0) { Time.timeScale *= winSlowMotion; sceneLoader.NextLevel(); }
    }


    //Pause System
    void PauseGame()
    {
        if (pauseOn)
        {
            Time.timeScale = gameSpeed;//unpause
            pauseOn = false;
        }
        else
        {
            Time.timeScale = 0;//pause
            pauseOn = true;
        }
    }


    private void OnDestroy() { Time.timeScale = 1; }
}
