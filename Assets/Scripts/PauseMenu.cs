using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
            Resume();

    }
    public void Pause()
    {
        menuPausa.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;

    }
    public void Resume()
    {
        menuPausa.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }


}
