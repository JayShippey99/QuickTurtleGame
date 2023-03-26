using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int highscore;

    public GameObject menu;

    public bool playing;

    public void GoToGame()
    {
        menu.SetActive(false);
        playing = true;
    }

    
}
