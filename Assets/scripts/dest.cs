using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dest : MonoBehaviour
{
    [SerializeField] GameObject[] _platform;
   void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log(other.gameObject.name);
    }
}
