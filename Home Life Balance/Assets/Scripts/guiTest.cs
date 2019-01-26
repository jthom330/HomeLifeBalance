using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(transform.position.x, transform.position.y, 100, 100), string.Format("{0}", "test"));
        }
    }
}
