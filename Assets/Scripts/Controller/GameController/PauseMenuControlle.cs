using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuControlle : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    [SerializeField] Sprite buttonOn, buttonOff;
    [SerializeField] Button toggleButton;

    private VolumeSetting volume;
    public static PauseMenuControlle instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        volume = GameObject.FindGameObjectWithTag("VolumeSetting").GetComponent<VolumeSetting>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            { 
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        volume.SettingOff();
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Option()
    {
        volume.settingUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
   
}
