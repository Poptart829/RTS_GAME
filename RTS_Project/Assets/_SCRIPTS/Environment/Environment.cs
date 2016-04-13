using UnityEngine;
using System.Collections;

public class Environment : BaseObject
{
    public enum ENVIRONMENT_TYPE
    {
        DEFAULT, ROCKS, LEVEL, WATER
    };

    public ENVIRONMENT_TYPE myEType;
    public bool isBreakable = false;

    // Use this for initialization
    void Start ()
    {
        myType = OBJECT_TYPE.ENVIRONMENT;
        myEType = ENVIRONMENT_TYPE.DEFAULT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
   
    public override void OnClick(RaycastHit _clickedOn, bool isAgressive = false)
    {
        Debug.Log("OnClick Enviornment");
    }
    
}
