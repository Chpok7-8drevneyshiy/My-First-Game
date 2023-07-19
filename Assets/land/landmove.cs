using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class landmove : MonoBehaviour
{
    [SerializeField] float _speed;
    private change planes;
    private void Awake()
    {
        planes = FindObjectOfType<change>();
    }
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * (1 + planes.Counter*0.1f) , 0 , 0);
    }
}
