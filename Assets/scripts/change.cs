using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class change : MonoBehaviour
{
     Animator anim;
    [SerializeField] GameObject[] _planes;
    [SerializeField] float _interval; //200
    [SerializeField] Text ScoreText; 
    GameObject _main;
    public int Counter =0;
    private float _score;
    [SerializeField]GameObject _max;
    private void Awake()
    {
        anim = _max.GetComponent<Animator>();
    }
    private void Start()
    {
        _main = _planes[Counter];
        _main.SetActive(true);
    }
    private void Update()
    {
/*        if (Counter > _planes.Length)
        {
            Counter = _planes.Length;
        }*/
        _score = float.Parse(ScoreText.text);

            if (_score < _interval * Counter || _score > _interval * (Counter + 1))
            {

            {
                if (_score < _interval * Counter)
                    if (Counter > 0)
                    {
                        anim.SetBool("start", true);
                        if (_max.transform.localScale == Vector3.zero)
                        {
                            Counter--;
                            _main.SetActive(false);
                            _main = _planes[Counter];
                            _main.SetActive(true);
                            anim.SetBool("start", false);
                        }
                    }
                if (Counter < _planes.Length - 1)
                    if (_score > _interval * (Counter + 1))
                    {
                        anim.SetBool("start", true);
                        if (_max.transform.localScale == Vector3.zero)
                        {
                            Counter++;
                            _main.SetActive(false);
                            _main = _planes[Counter];
                            _main.SetActive(true);
                            anim.SetBool("start", false);
                        }
                    }
            }
            }
        
    }
}
