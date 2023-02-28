using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        AudioController.instance.SaveMusic();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
      VolumeSetting.instance.settingUI.SetActive(true);
    }

    void Start()
    {
        AudioController.instance.PlayMusic("Menu");
    }

}
