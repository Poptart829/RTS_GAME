using UnityEngine;
using System.Collections;

public class Unit : BaseObject
{
    public enum UNIT_TYPE
    {
        DEFAULT, WORKER, ATT_UNIT1, ATT_UNIT2
    };
    public Unit.UNIT_TYPE myUnitType;
	// Use this for initialization
	void Start ()
    {
        myUnitType = UNIT_TYPE.DEFAULT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
