﻿using UnityEngine;
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
    void Start ()
    {
        myRType = RESOURCE_TYPE.DEFAULT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddMiner(GameObject _obj)
    {
        bool found = false;
        for (int x = 0; x < maxMiners; x++)
        {
            if (CurrentMiners[x].Miner == null)
            {
                CurrentMiners[x].Miner = _obj;
                CurrentMiners[x].time = MiningRate;
                NumMiners++;
                found = true;
                break;
            }
        }
        if (found == false)
        {
            _obj.GetComponent<Worker>().FindClosestMineralPatch();
        }
    }



}
