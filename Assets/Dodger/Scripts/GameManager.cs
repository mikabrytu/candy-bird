using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum Scene { Menu, Game, GameOver };

    private ScoreController scoreController;
    private UIManager uiManager;
    private AudioManager audioManager;
    private GameObject particleManager;
    private CandyManager candyManager;

    [SerializeField]
    private GameObject enemySpawn;

    private Scene currentScene;
    private bool isRunning;

    void Start()
    {
        // DEBUG
        // Clear unlocked birds
        //PlayerPrefs.DeleteKey("unlocked-birds");

        scoreController = GameObject.Find("Canvas").GetComponent<ScoreController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        particleManager = GameObject.Find("Particle Manager");

        candyManager = GetComponent<CandyManager>();
        
        isRunning = true;

        GoToMenu();
    }

    void Update()
    {
        if (particleManager.transform.childCount > 50)
            ClearVFX();
    }


    /* Game Running Manager */

    public bool IsRunning()
    {
        return isRunning;
    }

    public void StartGame()
    {
        isRunning = true;

        ClearVFX();

        scoreController.ResetScore();
        enemySpawn.GetComponent<EnemySpawn>().ResetDifficulty();
        enemySpawn.SetActive(true);
    }

    public void StopGame()
    {
        isRunning = false;
        
        enemySpawn.SetActive(true);

        GoToGameOver();
    }


    /* Scene Manager */

    public Scene GetCurrentScene()
    {
        return currentScene;
    }

    public void GoToMenu()
    {
        currentScene = Scene.Menu;
        audioManager.PlayIntroSoundTrack();
        uiManager.SetUI(currentScene);
        uiManager.ShowCandyCount(candyManager.GetCandyValue().ToString());
    }

    public void GoToGame()
    {
        currentScene = Scene.Game;
        audioManager.PlayGameSoundTrack();
        uiManager.SetUI(currentScene);

        StartGame();
    }

    public void GoToGameOver()
    {
        currentScene = Scene.GameOver;
        scoreController.SetFinalScore();
        uiManager.SetUI(currentScene);
    }

    public void ClearVFX()
    {
        for (int i = 0; i < particleManager.transform.childCount; i++)
        {
            Destroy(particleManager.transform.GetChild(i).gameObject);
        }
    }


    /* Bird Library Manager */

    public void NextBird()
    {
        
    }
    
}
