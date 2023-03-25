using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public Vector3 offset;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.position = player.position - transform.forward * 5 + offset;
        transform.position = new Vector3(transform.position.x, offset.y, transform.position.z);
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        //if (Input.GetKeyDown(KeyCode.R)) {
        //    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, player.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        //}
    }
}
