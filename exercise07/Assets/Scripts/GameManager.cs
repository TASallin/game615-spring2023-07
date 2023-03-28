using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pineapples;
    public GameObject uiImage;
    public TMP_Text uiText;
    public TMP_Text mothHint;
    float hintTimer;
    public string nextHint;
    public bool foundPineapple;
    public List<GameObject> collectibles;
    bool noPineapples;
    public AudioSource collectSound;
    public AudioSource explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        SetHint("Hold and release W to bounce");
    }

    // Update is called once per frame
    void Update()
    {
        if (hintTimer > 0) {
            hintTimer -= Time.deltaTime;
            if (hintTimer <= 0) {
                mothHint.text = "";
            }
        } else {
            if (nextHint != "") {
                SetHint(nextHint);
                nextHint = "";
            } else {
                uiImage.SetActive(false);
            }
        }
        if (pineapples > 0) {
            uiImage.SetActive(true);
            if (pineapples > 1) {
                uiText.text = "" + pineapples;
            } else {
                uiText.text = "";
            }
        }
    }

    public void SetHint(string hint) {
        mothHint.text = hint;
        hintTimer = 5f;
    }

    public void AddPineapple() {
        pineapples += 1;
        collectSound.Play();
        if (!foundPineapple) {
            foundPineapple = true;
            SetHint("Hold and release Space to chuck a pineapple");
            nextHint = "Defeat Pizza Steve to win!";
        }
    }

    public void BadAim() {
        switch (new System.Random().Next(5)) {
            case 0:
                SetHint("... you missed");
                break;
            case 1:
                SetHint("Talk about a skill issue");
                break;
            case 2:
                SetHint("You're supposed to throw the pineapple TOWARDS the pizza");
                break;
            case 3:
                SetHint("NA aim");
                break;
            case 4:
                SetHint("What was that supposed to be?");
                break;
        }
    }

    public void CheckSoftlocked() {
        explodeSound.Play();
        if (pineapples <= 0) {
            bool softlocked = true;
            foreach (GameObject g in collectibles) {
                if (g.activeInHierarchy) {
                    softlocked = false;
                }
            }
            if (softlocked) {
                int index = new System.Random().Next(collectibles.Count);
                collectibles[index].SetActive(true);
                if (!noPineapples) {
                    SetHint("You really wasted them all? Fine, I'll make a pineapple respawn somewhere...");
                    noPineapples = true;
                }
            }
        }
    }
}
