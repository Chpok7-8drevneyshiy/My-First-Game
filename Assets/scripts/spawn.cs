using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class spawn : MonoBehaviour
{   
    [SerializeField] float speed;
    [SerializeField] Image time_;
    private change planes;
     public GameObject[] objects;
    void Start()
    {
            planes = FindObjectOfType<change>();
            StartCoroutine(Ob());      
    }
    IEnumerator Ob()
    {
        yield return new WaitForSeconds(speed-(planes.Counter*0.05f));
        int randP = Random.Range(0, 3);
        int rand;
        if (randP == 0)
        {
            rand = Random.Range(0, objects.Length);
            Instantiate(objects[rand], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
        }
        if (randP == 1)
        {
            rand = Random.Range(0, objects.Length);
            Instantiate(objects[rand], new Vector3(0.875f, 2.07f, 46.532f), Quaternion.identity);
        }
        if (randP == 2)
        {
            rand = Random.Range(0, objects.Length);
            Instantiate(objects[rand], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
            rand = Random.Range(0, objects.Length);
            Instantiate(objects[rand], new Vector3(0.875f, 2.07f, 46.532f), Quaternion.identity);
        }
        Rep();
    } 
    
    void Rep()
    { time_ = GameObject.Find("TimeLine").GetComponent<Image>();
        if  (time_.fillAmount <1)
        StartCoroutine(Ob());
    }


    IEnumerable Spawn()
    {
        yield return new WaitForSeconds(speed - (planes.Counter * 0.05f));
        int type = Random.Range(0, 2);
        int positive = Random.Range(0, 2);
        int tier = Random.Range(0, 2);
    }







    /*   IEnumerator Ob1()
       {
           yield return new WaitForSeconds(speed);
           int chance = Random.Range(0, 9);
           int rand;
           int randt;
           int randp;




           if (chance > 5)      //good math
           {
               rand = Random.Range(0, 99);         //difinition of tiers 0-50 t1, 51-80 t2, 81-99 t3
               if (rand >= 0 && rand <= 50)     //tier 1
               {
                   randt = Random.Range(0, 2);
                   if (randt == 0)
                       Instantiate(objects[0], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
                   if (randt == 1)
                       Instantiate(objects[1], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
                   if (randt == 2)
                       Instantiate(objects[2], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }
               if (rand >= 51 && rand <= 80) //tier 2
               {
                   Instantiate(objects[10], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }
               if (rand >= 81)
               {
                   randt = Random.Range(0, 2);
                   if (randt == 0 || randt == 1)
                   {
                       Instantiate(objects[9], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
                   }
                   if (randt == 2)
                       Instantiate(objects[12], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }

           }

           if (chance <= 5)    //bad math
           {
               rand = Random.Range(0, 3);
               if (rand == 0)
               {
                   randt = Random.Range(0, 1);
                   if (randt == 0)
                       Instantiate(objects[3], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
                   if (randt == 1)
                       Instantiate(objects[4], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }
               if (rand == 1)
               {
                   Instantiate(objects[6], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }
               if (rand == 2)
               {
                   randt = Random.Range(0, 1);
                   if (randt == 0)
                       Instantiate(objects[11], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
                   if (randt == 1)
                       Instantiate(objects[0], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
               }
               if  (rand == 3)
                   Instantiate(objects[0], new Vector3(3.41f, 2.07f, 46.532f), Quaternion.identity);
           }

       }*/









    /*    private void Update()
        {
            int rand = Random.Range(0, objects.Length);
            Instantiate (objects[rand], new Vector3(0.875f, 1.03f, 46.532f), Quaternion.identity);
        }*/

}