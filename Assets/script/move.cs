using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    public float speedLR;
    private bool flagM;
    private bool upStop;
    private bool downStop;
    private float penal = 5;

    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        upStop = false;
        downStop = false;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            flagM = true;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            flagM = true;

        }
        else
        {
            flagM = false;
        }

        if (Input.GetKey(KeyCode.A) && flagM && upStop == false)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            downStop = false;
        }
        else if (Input.GetKey(KeyCode.D) && flagM && downStop == false)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            upStop = false;
        }
        rig.velocity = new Vector3(0, 0, 0);
        rig.angularVelocity = new Vector3(0, 0, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bug")
        {
            Destroy(collision.gameObject);
            score.curTime += penal;
        }else if(collision.gameObject.tag == "TribuneUp"){
            upStop = true;
        }
        else if (collision.gameObject.tag == "TribuneDown"){
            downStop = true;
        }
    }

}