using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawAnimation : MonoBehaviour
{
    public ChainsawSteve s;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer() {
        s.KillPlayer();
    }

    public void Recover() {
        s.Recover();
    }
}
