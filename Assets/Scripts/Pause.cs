using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject mobileButtonsCanvas;

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        mobileButtonsCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        mobileButtonsCanvas.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
