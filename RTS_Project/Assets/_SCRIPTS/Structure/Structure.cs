using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Structure : BaseObject
{
    public enum STRUCT_TYPE
    {
        DEFAULT, MAP, HOMEBASE, RAX, FACTORY, STARPORT
    };

    public STRUCT_TYPE myStructType;
    public float SphereRadius = 30.0f;
    protected List<GameObject> ResourcePatches;
    // Use this for initialization
    void Start ()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.DEFAULT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    virtual public void ClosetestResorucePatches()
    {

    }
}
