using UnityEngine;
using System.Collections;

public class Worker : Unit
{
    private bool goingHome = false;
	// Use this for initialization
	void Start ()
    {
        myType = OBJECT_TYPE.UNIT;
        myUnitType = UNIT_TYPE.WORKER;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
