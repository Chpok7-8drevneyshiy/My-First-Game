using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Land;


    private void OnTriggerExit(Collider other)
    {
        Instantiate(Land[Random.Range(0, Land.Length)], new Vector3(36, -20, 261-4.6f), Quaternion.Euler(new Vector3(0, -90, 0)));
        Debug.Log("123");
    }
}
