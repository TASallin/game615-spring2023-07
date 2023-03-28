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
    public Transform powerMeter;
    public Transform pineappleMeter;
    public GameObject appleJuice;
    public GameObject gameOver;
    float cooldown;
    public AudioSource landSound;
    bool jumped;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        powerMeter.localScale = new Vector3(1, power / maxPower, 1);
        pineappleMeter.localScale = new Vector3(1, pineapplePower / maxPower, 1);

        if (cooldown <= 0) {
            if (Input.GetKey(KeyCode.W)) {
                power = Mathf.Min(power + Time.deltaTime * 200, maxPower);
            }

            if (Input.GetKeyDown(KeyCode.W)) {
                power = minPower;
            }

            if (Input.GetKeyUp(KeyCode.W)) {
                rb.AddForce(camera.forward * power + Vector3.up * power / 2);
                power = 0;
                cooldown = 1.5f;
                jumped = true;
            }
        } else {
            cooldown -= Time.deltaTime;
        }
        

        if (gm.pineapples > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pineapplePower = Mathf.Min(pineapplePower + Time.deltaTime * 200, maxPower);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                pineapplePower = minPower;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameObject pineapple = Instantiate(projectile, transform.position + camera.forward + Vector3.up, Quaternion.identity);
                pineapple.GetComponent<Projectile>().steve = steve;
                pineapple.GetComponent<Projectile>().gm = gm;
                pineapple.GetComponent<Rigidbody>().AddForce(camera.forward * pineapplePower * 1.2f + Vector3.up * pineapplePower * 0.4f);
                pineapplePower = 0;
                gm.pineapples -= 1;
            }
        }

    }

    public void Juice() {
        appleJuice.SetActive(true);
        appleJuice.transform.LookAt(camera.position);
        //appleJuice.transform.Rotate(90, 0, 0);
    }

    public void GameOver() {
        gameOver.SetActive(true);
    }

    void OnCollisionEnter(Collision other) {
        if (jumped) {
            landSound.Play();
            jumped = false;
        }
    }
}
