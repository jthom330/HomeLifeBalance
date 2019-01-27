using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public int multiplier;
    public float resetTimer = 5f;
    private bool wasTouching = false;

    private void Update()
    {
        resetTimer -= Time.deltaTime;
        if (resetTimer <= 0)
        {
            if (wasTouching)
            {
                Debug.Log("score should half");

                ScoreManager.score = ScoreManager.score / 2;
                wasTouching = false;
            }
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("touching trigger");

        // add multiplier
        if (!wasTouching)
        {
            Debug.Log("score should double");
            ScoreManager.score = ScoreManager.score * 2;
            wasTouching = true;
        }
        

        resetTimer = 5f;
    }    
}
