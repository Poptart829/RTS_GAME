using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnGUI()
    {
        string toDisplay = "Mineral Count";
        GUI.Label(new Rect(10,10,100,20), toDisplay);
    }

}
