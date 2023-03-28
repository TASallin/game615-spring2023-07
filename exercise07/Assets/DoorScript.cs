using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject woodChips;
    public GameObject door;
    float countdown;
    bool broken;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        countdown = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) {
            countdown -= Time.deltaTime;
            if (countdown < 4) {
                woodChips.SetActive(true);
            }
            if (countdown <= 0) {
                woodChips.SetActive(false);
                door.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (broken || open) {
            return;
        }
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("EnterFront", true);
            open = true;

        } else if (other.CompareTag("Steve")) {
            other.gameObject.GetComponent<ChainsawSteve>().SawDoor();
            other.transform.LookAt(transform.position);
            countdown = 5f;
            broken = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (broken || !open) {
            return;
        }
        if (other.CompareTag("Player")) {
            doorAnimator.SetBool("EnterFront", false);
            open = false;
        }
    }

}
