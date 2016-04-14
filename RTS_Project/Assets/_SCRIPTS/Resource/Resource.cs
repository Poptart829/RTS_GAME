using UnityEngine;
using System.Collections;

public class Resource : BaseObject
{
    public enum RESOURCE_TYPE
    {
        DEFAULT, MINERAL, SILVER
    };
    public struct MinerStruct
    {
        public GameObject Miner;
        public float time;
    };
    public float MiningRate = 0.5f;
    public MinerStruct[] CurrentMiners;
    public RESOURCE_TYPE myRType;
    public int NumMiners = 0;
    public int maxMiners = 2;

    // Use this for initialization
    void Start()
    {
        myRType = RESOURCE_TYPE.DEFAULT;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision _col)
    {
        Worker w = _col.gameObject.GetComponent<Worker>();
        if (w)
        {
            w.transform.LookAt(null);
            w.GetMyRBody().velocity = Vector3.zero;
            Debug.Log(w.gameObject.name + " hit " + gameObject.name);
            AddMiner(w.gameObject);
        }
    }

    public void AddMiner(GameObject _obj)
    {
        bool found = false;
        for (int x = 0; x < maxMiners; x++)
        {
            if (CurrentMiners[x].Miner == null)
            {
                Debug.Log("adding " + _obj.name);
                CurrentMiners[x].Miner = _obj;
                CurrentMiners[x].time = MiningRate;
                NumMiners++;
                found = true;
                break;
            }
        }
        if (found == false)
        {
            Worker w = _obj.GetComponent<Worker>();
            if (w)
            {
                w.FindClosestMineralPatch();
                w.GetTargetResource().GetComponent<Resource>().AddMiner(w.gameObject);
                w.Move(w.GetTargetResource().transform.position);
            }

        }
    }



}
