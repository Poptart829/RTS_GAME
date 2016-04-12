using UnityEngine;
using System.Collections;

public class Resource : BaseObject
{
    public enum RESOURCE_TYPE
    {
        DEFAULT, MINERAL, SILVER
    };

    public RESOURCE_TYPE myRType;

	// Use this for initialization
	void Start ()
    {
        myRType = RESOURCE_TYPE.DEFAULT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
