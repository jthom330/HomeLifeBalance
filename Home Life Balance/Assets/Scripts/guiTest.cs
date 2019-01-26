using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiTest : MonoBehaviour
{
	public Font font;
	
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
			GUI.skin.label.font = font;
            GUI.skin.label.wordWrap = false;
            GUI.skin.label.clipping = 0;
            GUI.Label(new Rect(4, 16 * 0, 100, 100), string.Format("{0}", "test"));
        }
    }
}
