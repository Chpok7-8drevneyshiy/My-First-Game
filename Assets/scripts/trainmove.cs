using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class trainmove : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0); 
    }
}
