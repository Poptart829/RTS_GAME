using UnityEngine;
using System.Collections;

public class Worker : Unit
{
    private bool goingHome = false;
    public float moveSpeed = 17.0f;
    public Transform MineralAttachSpot;
    private GameObject attachedPrefab;
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
        MineralAttachSpot = MineralAttachSpot.GetComponent<Transform>();
        SetMoveTo(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //move to where ever i need to go
        Move(GetMoveToPos());
    }

    public override void Move(Vector3 _moveTo, bool _GoingHome = false)
    {
        if (_GoingHome)
            goingHome = _GoingHome;
        transform.LookAt(_moveTo);
        SetMoveTo(_moveTo);
        transform.position = Vector3.MoveTowards(transform.position, _moveTo, moveSpeed * Time.deltaTime);
        float d = (GetMoveToPos() - transform.position).magnitude;
        if (d < 1.0f)
        {
            if (goingHome)
            {
                goingHome = false;
                targetBase.GetComponent<HomeBase>().AddMinerals(CarryAmount);
                DetachPrefab();
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
        targetResource = targetBase.GetComponent<HomeBase>().GetAPatch();
    }

    //fills out the targetbase for the worker
    public void FindClosetBase()
    {
        if (targetBase == null)
        {
            GameObject[] HomeBase = GameObject.FindGameObjectsWithTag("Base");
            float distance = float.MaxValue;
            foreach (GameObject b in HomeBase)
            {
                if ((transform.position - b.transform.position).magnitude < distance)
                    targetBase = b;
            }
        }
    }

    public void AttachPrefab(GameObject _prefab)
    {
        if (attachedPrefab == null)
        {
            GameObject g = Instantiate(_prefab, MineralAttachSpot.position, Quaternion.identity) as GameObject;
            attachedPrefab = g;
            attachedPrefab.transform.SetParent(transform);
        }
    }

    public void DetachPrefab()
    {
        if (attachedPrefab != null)
        {
            attachedPrefab.transform.SetParent(null);
            Destroy(attachedPrefab);
        }
    }

}

