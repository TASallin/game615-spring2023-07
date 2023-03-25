using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChainsawSteve : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Animator anim;
    public Animator pizzaAnim;
    public Animator playerAnimL;
    public Animator playerAnimR;
    public Rigidbody playerRB;
    public CameraController camera;

    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && Vector3.Distance(transform.position, player.transform.position) < 1) {
            agent.enabled = false;
            anim.SetTrigger("Attack");
            playerRB.isKinematic = true;
            playerRB.transform.rotation = Quaternion.identity;
            playerRB.transform.position = transform.position + transform.forward;
            camera.enabled = false;
            camera.transform.position = transform.position + transform.forward * 4;
            camera.transform.LookAt(transform.position + new Vector3(0, 1, 0));
        }
    }

    public void KillPlayer() {
        playerAnimL.enabled = true;
        playerAnimR.enabled = true;
    }

    public void Damage() {
        if (camera.enabled) {
            anim.SetTrigger("Damage");
            pizzaAnim.SetTrigger("Damage");
            agent.enabled = false;
        }
    }

    public void Recover() {
        agent.enabled = true;
        SetTarget();
    }

    void SetTarget() {
        agent.SetDestination(player.transform.position);
    }
}
