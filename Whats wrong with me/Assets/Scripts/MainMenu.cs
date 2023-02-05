using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public string menuLevel;

    public GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(menuLevel);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quitting.");
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
    }
}
