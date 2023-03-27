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
    public float countdown;
    Vector3 target;
    public int hp;
    public AudioSource sawStartSound;
    public AudioSource sawingSound;

    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
        hp = 5;
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

        if (agent.enabled) {
            countdown -= Time.deltaTime;
            if (countdown <= 0 || Vector3.Distance(transform.position, target) < 0.5f) {
                SetTarget();
            }
        }
    }

    public void KillPlayer() {
        playerAnimL.enabled = true;
        playerAnimR.enabled = true;
    }

    public void Damage() {
        if (camera.enabled) {
            hp -= 1;
            if (hp > 0) {
                anim.SetTrigger("Damage");
                pizzaAnim.SetTrigger("Damage");
                agent.enabled = false;
            } else {
                anim.SetTrigger("Die");
                pizzaAnim.SetTrigger("Die");
                agent.enabled = false;
            }
        }
    }

    public void Recover() {
        agent.enabled = true;
        SetTarget();
    }

    void SetTarget() {
        if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
            Vector3 randomDirection = new Vector3(Random.Range(0, 5), transform.position.y, Random.Range(0, 5));
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(player.transform.position + randomDirection, out hit, 5, 1)) {
                finalPosition = hit.position;
            }
            agent.SetDestination(finalPosition);
            target = finalPosition;
        } else {
            agent.SetDestination(player.transform.position);
            target = player.transform.position;
        }
        countdown = Random.Range(3f, 10f);
    }

    public void SawDoor() {
        agent.enabled = false;
        anim.SetTrigger("Break");
    }

    public void PlaySawAudio() {
        sawingSound.Play();
    }

    public void PlaySawStartAudio() {
        sawStartSound.Play();
    }
}
