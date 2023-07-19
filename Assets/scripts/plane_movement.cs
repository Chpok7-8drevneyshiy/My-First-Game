using UnityEngine;
using UnityEngine.UI;
public class plane_movement : MonoBehaviour
{
    [SerializeField] KeyCode KeyCode1;
    [SerializeField] KeyCode KeyCode2;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnspeed;
    [SerializeField] float turnspeedback;/* Vector3(1.58f, 1.9f, -16.4f)*/
    Vector3 pos;
    [SerializeField] Text ScoreText;
    float score;
    [SerializeField] float movespeedback;
    [SerializeField] Rigidbody skyboxleft;
    [SerializeField] Rigidbody skyboxright;
    private float screen;

     void OnCollisionStay (Collision other)
    {
        GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeedback );

    }
    private void Start()
    {
        screen = Screen.width;
        score = 50;
        ScoreText.text = score.ToString();  
    }

    private void FixedUpdate()
    {
        pos = new Vector3(2.183f, 1.9f, -16.4f);


        int i = 0;
        while (i < Input.touchCount)
        {   if (Input.GetTouch(i).position.x > screen / 2 && Input.GetTouch(i).position.x < screen / 2)
            {
                GetComponent<Rigidbody>().transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * movespeedback); //!!!!!!!!!!!!!!!!!
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeedback * 2);
            }
            else { 
            if (Input.GetTouch(i).position.x > screen / 2)
            {
                GetComponent<Rigidbody>().velocity += moveDirection * Time.deltaTime * moveSpeed;
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * turnspeed);
            }
            if (Input.GetTouch(i).position.x < screen / 2)
            {
                GetComponent<Rigidbody>().velocity -= moveDirection * Time.deltaTime * moveSpeed;
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime * turnspeed);
            }
                }
            ++i;
        }


        if (Input.GetKey(KeyCode1) && Input.GetKey(KeyCode2))
        {
            GetComponent<Rigidbody>().transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * movespeedback);
            GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeedback * 2);
        }
        else
        {
            if (Input.GetKey(KeyCode1))
            {
                GetComponent<Rigidbody>().velocity += moveDirection * Time.deltaTime * moveSpeed;
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * turnspeed);
            }
            if (Input.GetKey(KeyCode2))
            {
                GetComponent<Rigidbody>().velocity -= moveDirection * Time.deltaTime * moveSpeed;
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime * turnspeed);
            }
            if (Input.anyKey == false)
            {
                GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeedback);
            }
        }


    }

}

        /*           if (GetComponent<Rigidbody>().rotation.x > 30 && GetComponent<Rigidbody>().rotation.x < -30)
                {
                    GetComponent<Rigidbody>().transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeedback*2);
                }*/
        /* public GameObject obj;
         public float range = 5f;
         void FixedUpdate()
         {
             float h = Input.GetAxis("Horizontal");
             float zPos = h * range;
             obj.transform.position = new Vector3(0, 0, zPos);
         }*/



        /*    float speed = 10.0f;
            void Update()
            {
                Vector3 dir = Vector3.zero;

                // we assume that device is held parallel to the ground
                // and Home button is in the right hand

                // remap device acceleration axis to game coordinates:
                //  1) XY plane of the device is mapped onto XZ plane
                //  2) rotated 90 degrees around Y axis
                dir.x = -Input.acceleration.y;
                dir.z = Input.acceleration.x;

                // clamp acceleration vector to unit sphere
                if (dir.sqrMagnitude > 1)
                    dir.Normalize();

                // Make it move 10 meters per second instead of 10 meters per frame...
                dir *= Time.deltaTime;

                // Move object
                transform.Translate(dir * speed);
            }*/