using UnityEngine;
using System.Collections;

public class Structure : BaseObject
{
    public Transform RalleyPoint;
    public Transform SpawnPoint;
    public enum STRUCT_TYPE
    {
        DEFAULT, MAP, HOMEBASE, RAX, FACTORY, STARPORT
    };

    public STRUCT_TYPE myStructType;
    
    // Use this for initialization
    void Start ()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.DEFAULT;
        RalleyPoint.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}



    virtual public void ClosetestResorucePatches()
    {

    }
}
