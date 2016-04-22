using UnityEngine;
using System.Collections;

public class Worker : Unit
{
    public Transform MineralAttachSpot;
    private GameObject attachedPrefab;
    private Transform targetBase;
    public Transform GetTargetBase() { return targetBase; }
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
    public int GetCarryAmount() { return CarryAmount; }
    public void SetCarryAmount(int _CA) { CarryAmount = _CA; }


    // Use this for initialization
    void Start()
    {

    }

    public override void OnSpawn(Vector3 _HeadingTo)
    {
        myType = OBJECT_TYPE.UNIT;
        myUnitType = UNIT_TYPE.WORKER;
        isMoveable = true;
        FindClosetBase();
        FindClosestMineralPatch();
        MineralAttachSpot = MineralAttachSpot.GetComponent<Transform>();
        targetBase = targetBase.GetComponent<Transform>();
        SetMoveTo(_HeadingTo);
        if (PlayerHUD == null)
            PlayerHUD = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //move to where ever i need to go
        Move(GetMoveToPos());
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
                //r.AddMiner(gameObject);
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
                    targetBase = b.transform;
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
            SetCarryAmount(0);
        }
    }

}

