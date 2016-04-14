using UnityEngine;
using System.Collections;

public class Unit : BaseObject
{
    public enum UNIT_TYPE
    {
        DEFAULT, WORKER, ATT_UNIT1, ATT_UNIT2
    };
    public Unit.UNIT_TYPE myUnitType;
    //protected bool isMoving = false;

    private Vector3 MoveToPos;
    public void SetMoveTo(Vector3 _pos)
    {
        MoveToPos = _pos;
    }
    public Vector3 GetMoveToPos()
    {
        return MoveToPos;
    }

    public enum BEHAVIOR_TYPE
    {
        DEFAULT, MINING, ATTACKING, MOVING
    };
    private BEHAVIOR_TYPE myBehavior;
    public void SetBehavior(BEHAVIOR_TYPE _BT) { myBehavior = _BT; }
    public BEHAVIOR_TYPE GetCurrentBehavior() { return myBehavior; }
    
	// Use this for initialization
	void Start ()
    {
        myUnitType = UNIT_TYPE.DEFAULT;
        isMoveable = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public virtual void Move(Vector3 _moveTo)
    {
        
    }

    public virtual void MakeDecision(RaycastHit _hit)
    {

    }
}
