using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public float timeLeft = 30;
    Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            timeText.text = timeLeft.ToString("F1");
        }
    }


    void DisableInventory() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("block")) {
            obj.SetActive(false);
        }
    }
}
