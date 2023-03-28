using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ChainsawSteve steve;
    public GameObject explosion;
    public GameManager gm;

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
        } else {
            gm.BadAim();
        }
        gm.CheckSoftlocked();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
