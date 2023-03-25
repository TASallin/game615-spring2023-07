using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 80, 0);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            gm.pineapples += 1;
            Destroy(gameObject);
        }
    }
}
