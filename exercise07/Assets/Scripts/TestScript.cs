using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public CharacterController cc;
    public Animator doorAnimator;
    public GameObject DoorTriggerFront;
    public GameObject DoorTriggerBack;
    //float timeRemaining = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, 80 * hAxis * Time.deltaTime, 0);
        cc.Move(transform.forward * vAxis * 5 * Time.deltaTime);
       
        Debug.Log(doorAnimator.GetBool("EnterBack"));

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DoorFront"))
        {
            doorAnimator.SetBool("EnterFront", true);
           // if(doorAnimator.GetBool("EnterFront") == true)
            {
                //DoorTriggerBack.GetComponent<Collider>().enabled = false;
            }
           
        }
       

        if (other.CompareTag("DoorBack"))
        {
            doorAnimator.SetBool("EnterBack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DoorFront"))
        {
            doorAnimator.SetBool("EnterFront", false);
            //timeRemaining -= Time.deltaTime;

        }


        if (other.CompareTag("DoorBack"))
        {
            doorAnimator.SetBool("EnterBack", false);
            // doorAnimator.SetBool("EnterBack", true);
        }
    }
}
