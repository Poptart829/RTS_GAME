using UnityEngine;
using System.Collections;

public class Worker : Unit
{
    private bool goingHome = false;
    private bool isMoving = false;
    public float moveSpeed = 17.0f;
    private GameObject targetBase;
    private GameObject targetResource;
    private int CarryAmount = 0;
	public void SetCarryAmount(int _CA) { CarryAmount = _CA; }
    // Use this for initialization
	void Start ()
    {
        myType = OBJECT_TYPE.UNIT;
        myUnitType = UNIT_TYPE.WORKER;
        isMoveable = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isMoving)
        {
            Move(GetMoveToPos());
        }
	}

    public override void Move(Vector3 _moveTo)
    {
        transform.LookAt(_moveTo);
        isMoving = true;
        SetMoveTo(_moveTo);
        transform.position = Vector3.MoveTowards(transform.position, _moveTo, moveSpeed * Time.deltaTime);
        float d = (GetMoveToPos() - transform.position).magnitude;
        if (d < 1.0f)
        {
            isMoving = false;
            if (goingHome)
            {
                goingHome = false;
                targetBase.GetComponent<HomeBase>().AddMinerals(CarryAmount);
                targetResource.GetComponent<Resource>().AddMiner(gameObject);
                Move(targetResource.transform.position);
            }
        }
    }

    public override void MakeDecision(RaycastHit _hit)
    {
        BaseObject.OBJECT_TYPE oType = _hit.transform.gameObject.GetComponent<BaseObject>().myType;
        switch (oType)  
        {
            case OBJECT_TYPE.BASE_TYPE:
                break;
            case OBJECT_TYPE.STRUCUTRE:
                break;
            case OBJECT_TYPE.RESOURCE:
                //currently gathering minerals
                Resource r = _hit.transform.gameObject.GetComponent<Resource>();
                r.AddMiner(gameObject);
                targetResource = r.gameObject;
                Move(targetResource.transform.position);
                break;
            case OBJECT_TYPE.UNIT:
                break;
            case OBJECT_TYPE.ENVIRONMENT:
                //if the user clicked on the map, move the object to that point
                Move(_hit.point);
                break;
            default:
                break;
        }
    }

    public void FindClosestMineralPatch()
    {
        //use base to get mineral patches
        //find closet mineral patch with less than max workers on it
        // go to that one and start mining XD
    }

    public void FindClosetBase()
    {
        goingHome = true;
        GameObject[] HomeBase = GameObject.FindGameObjectsWithTag("Base");
        float distance = float.MaxValue;
        foreach(GameObject b in HomeBase)
        {
            if ((transform.position - b.transform.position).magnitude < distance)
                targetBase = b;
        }

        Move(targetBase.transform.position);
    }

    public void ReturnToResource()
    {

    }

}
