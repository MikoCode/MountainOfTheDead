using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void CloseGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
