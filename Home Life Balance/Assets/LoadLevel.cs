using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.winConditionMet || TimeManager.loseConditionMet) {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
