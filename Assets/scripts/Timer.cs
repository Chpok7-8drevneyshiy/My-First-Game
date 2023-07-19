using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float maTime = 20f;
    float timeLeft;
    GameObject wn;
    private void Start()
    {   wn = GameObject.Find("win");
        wn.SetActive(false);
        
        timeBar = GetComponent<Image>();
        timeLeft = 0;
    }
    private void Update()
    {
        if(timeLeft < 60f)
        {
            timeLeft += Time.deltaTime;
            timeBar.fillAmount = timeLeft / maTime;
        }
        if (timeBar.fillAmount == 1)
        {
            wn.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
