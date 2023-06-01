using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    GameObject circle;
    GameObject maincircle;
    public Animator animator;
    public Text gameover, restart, nextlevel, leveltext;   
    bool control = true;
    
    
    void Start()
    {
        PlayerPrefs.SetInt("save", int.Parse(SceneManager.GetActiveScene().name));
        circle = GameObject.FindGameObjectWithTag("Circle");
        maincircle = GameObject.FindGameObjectWithTag("MainCircle");
        leveltext.text = SceneManager.GetActiveScene().name;
    }
    
    void Update()
    {
        

        if ((restart.text == "Press To Restart") && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("1");
        } 
        if ((nextlevel.text == "Congratulations! Press For Next Level") && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }

        if(maincircle.GetComponent<MainCircle>().currentneedle <= 0)
        {
            StartCoroutine(NewLevel());            
        }
    }

    IEnumerator NewLevel()
    {
        circle.GetComponent<CircleRotate>().enabled = false;
        maincircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(1);

        if(control)
        {
            animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(1);
            nextlevel.text = "Congratulations! Press For Next Level";            
            
        }
        
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCall());        
    }

    IEnumerator GameOverCall()
    {
        circle.GetComponent<CircleRotate>().enabled= false;
        maincircle.GetComponent<MainCircle>().enabled= false;
        animator.SetTrigger("GameOver");
        control = false;

        yield return new WaitForSeconds(2);
        gameover.text = " Game Over";
        restart.text = "Press To Restart";
        
    }
}
