using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image screen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (screen.color.a < 1) {
            screen.color = new Color(1, 1, 1, Mathf.Min(screen.color.a + Time.deltaTime, 1));
        }
    }
}
