using UnityEngine;
using System.Collections;

public class Worker : Unit
{
    private bool goingHome = false;
    private bool isMoving = false;
    public float moveSpeed = 17.0f;
    private GameObject targetBase;
    public GameObject GetTargetBase() { return targetBase; }
    private GameObject targetResource;
    public void SetTargetResource(GameObject _target)
    {
        if (targetResource == null)
            targetResource = _target;
        else
            Debug.Log("SetTargetResource() targetResource isn't null, ya derp");

    }
    public GameObject GetTargetResource() { return targetResource; }
    private int CarryAmount = 0;
    public void SetCarryAmount(int _CA) { CarryAmount = _CA; }
    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.UNIT;
        myUnitType = UNIT_TYPE.WORKER;
        isMoveable = true;
        FindClosetBase();
        FindClosestMineralPatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Move(GetMoveToPos());
        }
    }

    public override void Move(Vector3 _moveTo, bool _GoingHome = false)
    {
        if (_GoingHome)
            goingHome = _GoingHome;
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
        HomeBase b = targetBase.GetComponent<HomeBase>();
        targetResource = b.GetAPatch();
        
    }
    //fills out the targetbase for the worker
    public void FindClosetBase()
    {
        if (targetBase == null)
        {
            Debug.Log("findbase");
            GameObject[] HomeBase = GameObject.FindGameObjectsWithTag("Base");
            float distance = float.MaxValue;
            foreach (GameObject b in HomeBase)
            {
                if ((transform.position - b.transform.position).magnitude < distance)
                    targetBase = b;
            }
        }
    }

    public void ReturnToResource()
    {

    }

}
