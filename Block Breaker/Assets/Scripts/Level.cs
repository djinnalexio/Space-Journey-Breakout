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
    public int comboCount = 0;
    public bool pauseOn = false;

    public static int currentLayoutIndex = 0;
    public static bool lostALife = false;
    
    //External Scripts
    SceneLoader sceneLoader;
    GameSession gameSession;

    [SerializeField] GameObject[] blockLayoutList;

    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void PickLayout()
    {
        if (gameSession.GetLevelCount() <= blockLayoutList.Length) //if current stage lower than or equal to number of layout
        {
            currentLayoutIndex = gameSession.GetLevelCount() - 1;   
        }
        else if (!lostALife)  { currentLayoutIndex = UnityEngine.Random.Range(0, blockLayoutList.Length); }
    }

    public void ComboIncrease()
    { 
        comboCount++;
        gameSession.UpdateHighCombo(comboCount);
    }
    public void ComboReset() { comboCount = 0; }


    void Start()
    {
        Time.timeScale = gameSpeed;
        PickLayout();
        blockLayoutList[currentLayoutIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

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
        if (Input.GetMouseButtonDown(1))
        {
            if (pauseOn) {
                Time.timeScale = gameSpeed;//unpause
                pauseOn = false;
            }
            else {
                Time.timeScale = 0;//pause
                pauseOn = true;
            }
        }
    }

    public void SetLostLifeTrue() { lostALife = true; }
    public void SetLostLifeFalse() { lostALife = false; }


    private void OnDestroy() { Time.timeScale = 1; }
}
