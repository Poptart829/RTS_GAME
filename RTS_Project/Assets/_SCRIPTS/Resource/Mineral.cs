using UnityEngine;
using System.Collections;

public class Mineral : Resource
{
    public int MineralCap = 500;
    private int MineralsLeft;
    private int GatherAmount = 7;

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
                    scrub.FindClosetBase();
                    scrub.SetCarryAmount(GatherAmount);
                    GatherMinerals();
                    CurrentMiners[x].Miner = null;
                    CurrentMiners[x].time = MiningRate;
                    NumMiners--;
                }
            }
        }
    }

    public void GatherMinerals()
    {
        MineralsLeft -= GatherAmount;
        NumMiners = NumMiners - 1 < 0 ? 0 : NumMiners--;
    }








}
