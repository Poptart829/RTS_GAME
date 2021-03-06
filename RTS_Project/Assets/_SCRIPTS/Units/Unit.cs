﻿using UnityEngine;
using System.Collections;

public class Unit : BaseObject
{
    public enum UNIT_TYPE
    {
        DEFAULT, WORKER, ATT_UNIT1, ATT_UNIT2
    };
    public Unit.UNIT_TYPE myUnitType;
    //protected bool isMoving = false;
    public float moveSpeed = 17.0f;
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
    protected NavMeshAgent myAgent;
    
	// Use this for initialization
	void Start ()
    {
        myUnitType = UNIT_TYPE.DEFAULT;
        isMoveable = true;
        myAgent = GetComponent<NavMeshAgent>();
        if (myAgent == null)
            Debug.Log("nul");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public virtual void Move(Vector3 _moveTo)
    {
        SetMoveTo(_moveTo);
        myRigidBody.velocity = (_moveTo - transform.position).normalized * moveSpeed;
        float d = (_moveTo - transform.position).magnitude;
        if (d < 1.6f)
            myRigidBody.velocity = Vector3.zero;
        else
            transform.LookAt(_moveTo);
        myAgent.SetDestination(_moveTo);
    }

    public virtual void MakeDecision(RaycastHit _hit)
    {

    }

    public virtual void OnSpawn(Vector3 _HeadingTo )
    {

    }
}
