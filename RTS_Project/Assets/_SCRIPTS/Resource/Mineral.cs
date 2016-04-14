using UnityEngine;
using System.Collections;

public class Mineral : Resource
{
    public int MineralCap = 500;
    private int MineralsLeft;
    private int GatherAmount = 7;
    public GameObject MineralPrefab;
    public bool ShowDebugLines = true;
    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.RESOURCE;
        myRType = RESOURCE_TYPE.MINERAL;
        MineralsLeft = MineralCap;
        CurrentMiners = new MinerStruct[maxMiners];
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < maxMiners; x++)
        {
            if (CurrentMiners[x].Miner != null)
            {
                float d = (transform.position - CurrentMiners[x].Miner.transform.position).magnitude;
                if (d > 1.0f)
                    continue;
                CurrentMiners[x].time -= Time.deltaTime;
                if (CurrentMiners[x].time <= 0.0f)
                {
                    Worker scrub =  CurrentMiners[x].Miner.GetComponent<Worker>();
                    //find the closest base to return the minerals too
                    scrub.FindClosetBase();
                    //set the amount im going to carry
                    scrub.SetCarryAmount(GatherAmount);
                    //mineral class update to its remaining minerals
                    GatherMinerals();
                    //attach prefab to worker
                    scrub.AttachPrefab(MineralPrefab);
                    //start moving the working to ho home
                    scrub.Move(scrub.GetTargetBase().transform.position,true);
                    //reset the current miner at 'x' to allow more miners at this patch
                    ResetMiner(x);
                }
            }
        }
    }

    private void ResetMiner(int _who)
    {
        CurrentMiners[_who].Miner = null;
        CurrentMiners[_who].time = MiningRate;
    }

    public void GatherMinerals()
    {
        MineralsLeft -= GatherAmount;
        NumMiners--;
        if (NumMiners < 0)
            NumMiners = 0;
        
    }








}
