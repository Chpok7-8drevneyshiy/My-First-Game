using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{

    [SerializeField] Text Score;
    [SerializeField] GameObject pl;

    private void Start()
    { 
        pl.SetActive(false);
    }
    float score;
    public void Update()
    {

        score = float.Parse(Score.text);
        if (score <1)
        {    
           
           pl.SetActive(true);
           Time.timeScale = 0f;
            
          

        }


    }
    public void restart()
    {   
        Time.timeScale = 1f;

        Score.text = "50";
        SceneManager.LoadScene(0);
        
    }
}
