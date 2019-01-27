using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public float timeLeft = 30;
    Text timeText;
    public static bool winConditionMet = false;
    public static bool loseConditionMet = false;

    // Start is called before the first frame update
    void Start()
    {
        winConditionMet = false;
        loseConditionMet = false;
    }

    void Awake()
    {
        timeText = GetComponent<Text>();
        timeText.text = timeLeft.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if (timeLeft <= 0)
        {
            timeText.text = "0.0";
            timeText.color = Color.red;
            DisableInventory();
            CheckForWin();
        }
        else
        {
            timeText.text = timeLeft.ToString("F1");
        }

        if (winConditionMet) {
            DisableInventory();
            timeText.enabled = false;
        }
    }


    void DisableInventory() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("block")) {
            obj.SetActive(false);
        }
    }

    void CheckForWin()
    {
        bool isRoofPresent = false;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlacedBlock"))
        {
            if (obj.GetComponent<RoofWin>() && obj.activeSelf)
            {
                isRoofPresent = true;
            }
        }

        if (!isRoofPresent) {
            loseConditionMet = true;
            timeText.enabled = false;
        }
    }
}
