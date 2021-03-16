using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void toArena()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Exit()
    {
        Application.Quit();
    }
}