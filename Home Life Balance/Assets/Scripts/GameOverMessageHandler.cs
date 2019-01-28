using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessageHandler : MonoBehaviour
{
    float finalScore;
    Text finalMessageText;
    // Start is called before the first frame update
    void Start()
    {
        finalMessageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.winConditionMet) {
            finalScore = ScoreManager.score;
            finalMessageText.text = "Win!\nFinalScore: " + finalScore;
            finalMessageText.color = Color.green;
            Destroy(GameObject.Find("TimeManager"));
            Destroy(gameObject.GetComponent<GameOverMessageHandler>());
        }

        if (TimeManager.loseConditionMet)
        {
            finalScore = ScoreManager.score;
            finalMessageText.text = "You Lose";
            finalMessageText.color = Color.red;
            Destroy(GameObject.Find("TimeManager"));
            Destroy(gameObject.GetComponent<GameOverMessageHandler>());
        }
    }
}
