using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSlice : MonoBehaviour
{
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Juice() {
        pc.Juice();
    }

    public void GameOver() {
        pc.GameOver();
    }
}
