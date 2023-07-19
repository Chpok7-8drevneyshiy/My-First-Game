using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] float score_ ;

    private void Start()
    {
        score_ = float.Parse(scoreText.text);
    }
    private void OnTriggerEnter (Collider other) 
    {       


        if (other.gameObject.tag == "+100")
        {
            DestroyObject(other.gameObject);
            score_ += 100;
        }
        if (other.gameObject.tag == "-50")
        {
            DestroyObject(other.gameObject);
            score_ -= 50;
        }
        if (other.gameObject.tag == "x2")
        {
            DestroyObject(other.gameObject);
            score_ *= 2;
        }
        if (other.gameObject.tag == "x1.5")
        {
            DestroyObject(other.gameObject);
            score_ *= 1.5f;
        }
        if (other.gameObject.tag == "x3")
        {
            DestroyObject(other.gameObject);
            score_ *= 3;
        }
        if (other.gameObject.tag == "x0.5")
        {
            DestroyObject(other.gameObject);
            score_ *= 0.5f;
        }
        if (other.gameObject.tag == "+150")
        {
            DestroyObject(other.gameObject);
            score_ += 150;
        }
        if (other.gameObject.tag == "+20")
        {
            DestroyObject(other.gameObject);
            score_ += 20;
        }
        if (other.gameObject.tag == "+75")
        {
            DestroyObject(other.gameObject);
            score_ += 75;
        }
        if (other.gameObject.tag == "-300")
        {
            DestroyObject(other.gameObject);
            score_ -= 300;
        }
        if (other.gameObject.tag == "-100")
        {
            DestroyObject(other.gameObject);
            score_ -= 100;
        }
        if (other.gameObject.tag == "-150")
        {
            DestroyObject(other.gameObject);
            score_ -= 150;
        }
        if (other.gameObject.tag == "x0.75")
        {
            DestroyObject(other.gameObject);
            score_ *= 0.75f;
        }
    }


    void Update()
    {   if (score_ < 0)
        {
            score_ = 0;
        }
    if (score_ % 2 != 0)
        {
            score_ -= 0.5f;
        }
        scoreText.text = score_.ToString();
       
    }
}
