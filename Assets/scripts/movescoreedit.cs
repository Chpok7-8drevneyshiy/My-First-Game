using UnityEngine;
using UnityEngine.UI;

public class movescoreedit : MonoBehaviour
{
    [SerializeField] GameObject trigger;
    [SerializeField] float speed;
    private change planes;
    private void Awake()
    {
        planes = FindObjectOfType<change>();
    }
    void Update()
    {
        trigger.transform.Translate( 0, 0, -speed * Time.deltaTime * (1+planes.Counter*0.1f));
    }
}
