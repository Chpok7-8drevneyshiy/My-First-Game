using System.Collections;
using UnityEngine;

public class SpawnDecor : MonoBehaviour
{
    [SerializeField] GameObject[] city;

    private void Start()
    {
/*        StartCoroutine(Spawn2());*/
        StartCoroutine(Spawn1());
    }
    IEnumerator Spawn1()
    {
        Instantiate(city[Random.Range(0, city.Length)], new Vector3(36, -20, 261), Quaternion.Euler(new Vector3(0, -90, 0)));
        yield return new WaitForSeconds(Random.Range(0, 1));
        StartCoroutine(Spawn1());
    }
/*    IEnumerator Spawn2()
    {
        Instantiate(city[Random.Range(0, city.Length)], new Vector3(13, -2, 44.3f), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Spawn2());
    }*/
}

