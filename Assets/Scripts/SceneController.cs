using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
