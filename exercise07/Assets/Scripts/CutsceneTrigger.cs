using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    bool started;
    bool finished;
    public ChainsawSteve steve;
    public PlayerController pc;
    public Rigidbody playerRB;
    public CameraController camera;
    public AudioSource music;
    public Vector3 cameraA1;
    public Vector3 cameraA2;
    public Vector3 cameraB1;
    public Vector3 cameraB2;
    public Vector3 cameraC1;
    public Vector3 cameraC2;
    float countdown;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finished || !started) {
            return;
        }

        countdown += Time.deltaTime;
        if (countdown < 1) {
            camera.transform.position = cameraA1 + (cameraA2 - cameraA1) * countdown;
        } else if (countdown < 2) {
            camera.transform.position = cameraB1 + (cameraB2 - cameraB1) * (countdown - 1);
            camera.transform.LookAt(steve.transform.position);
        } else {
            camera.transform.position = cameraC1 + (cameraC2 - cameraC1) * .5f * (countdown - 2);
            camera.transform.LookAt(steve.transform.position);
            if (countdown > 4) {
                finished = true;
                camera.enabled = true;
                steve.agent.enabled = true;
                steve.SetTarget();
                playerRB.isKinematic = false;
                camera.transform.rotation = Quaternion.identity;
                gm.SetHint("Oh no! Run away or you'll be applesauce!");
                gm.nextHint = "I hear Pizza Steve hates pineapples";
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!started && other.tag == "Player") {
            started = true;
            camera.enabled = false;
            playerRB.isKinematic = true;
            camera.transform.position = cameraA1;
            camera.transform.LookAt(steve.transform.position);
            steve.PlaySawStartAudio();
            countdown = 0f;
            music.Play();
        }
    }
}
