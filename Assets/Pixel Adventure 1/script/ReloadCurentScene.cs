using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ReloadCurentScene : MonoBehaviour
{
    public void ReloadScene()
    {
        if (GameController.instance.isGameOver)
        {
            Time.timeScale = 1; 
            GameController.instance.isGameOver = false; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}