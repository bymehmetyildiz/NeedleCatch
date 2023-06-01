using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        int savelevel = PlayerPrefs.GetInt("save");

        if (savelevel == 0) 
        {
            SceneManager.LoadScene(savelevel + 1);
        }
        else 
        {
            SceneManager.LoadScene(savelevel);
        }
        
    }

    public void DeleteSave() 
    {
        PlayerPrefs.DeleteAll();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
   

}
