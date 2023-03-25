using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ChainsawSteve steve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (Vector3.Distance(steve.transform.position, transform.position) < 3) {
            steve.Damage();
        }
        Destroy(gameObject);
    }
}