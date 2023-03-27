using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pineapples;
    public GameObject uiImage;
    public TMP_Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pineapples > 0) {
            uiImage.SetActive(true);
            if (pineapples > 1) {
                uiText.text = "" + pineapples;
            } else {
                uiText.text = "";
            }
        } else {
            uiImage.SetActive(false);
        }
    }

}
