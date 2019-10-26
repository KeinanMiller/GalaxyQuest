using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Loadgame()
    {
        SceneManager.LoadScene(0); // loads the game
    }
}
