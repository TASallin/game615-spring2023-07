using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float power;
    public float pineapplePower;
    public float minPower;
    public float maxPower;
    public Transform camera;
    public GameObject projectile;
    public ChainsawSteve steve;
    public GameManager gm;
    public Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W)) {
            power = Mathf.Min(power + Time.deltaTime * 200, maxPower);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            power = minPower;
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            rb.AddForce(camera.forward * power + Vector3.up * power / 2);
            power = 0;
        }

        if (gm.pineapples > 0) {
            if (Input.GetKey(KeyCode.Space)) {
                pineapplePower = Mathf.Min(pineapplePower + Time.deltaTime * 200, maxPower);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                pineapplePower = minPower;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                GameObject pineapple = Instantiate(projectile, transform.position + camera.forward + Vector3.up, Quaternion.identity);
                pineapple.GetComponent<Projectile>().steve = steve;
                pineapple.GetComponent<Rigidbody>().AddForce(camera.forward * pineapplePower * 1.2f + Vector3.up * pineapplePower);
                pineapplePower = 0;
                gm.pineapples -= 1;
            }
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            doorAnimator.SetTrigger("doorCollision");
        }
    }
}
