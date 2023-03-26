using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int highscore;

    public GameObject menu;

    public bool playing;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void GoToGame()
    {
        menu.SetActive(false);
        playing = true;
    }

    
}
