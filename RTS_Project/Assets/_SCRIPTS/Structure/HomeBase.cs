﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HomeBase : Structure
{
    //how many minerals this current base has mined
    private int MineralCount = 0;
    //the patches which are close to the base
    protected List<GameObject> ResourcePatches;
    //the sphere of influence around the base which are this bases ResourcePatches
    public float SphereRadius = 30.0f;
    //the PlayerHUD
    public GameObject GetAPatch()
    {
        int r = Random.Range(0, ResourcePatches.Count);
        return ResourcePatches[r];
    }
    void Awake()
    {
        ResourcePatches = new List<GameObject>();
        ClosetestResorucePatches();
    }
    public GameObject WorkerPrefab;
    private float WorkerBuildTime = 1.0f;
    private float CurrentBuildTime = 0.0f;
    public float GetWorkerBuildTime() { return WorkerBuildTime; }
    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.HOMEBASE;
        RalleyPoint.position = RalleyPoint.position - transform.position;
        if (RalleyPoint.position.y < 0.0f)
            RalleyPoint.position = new Vector3(RalleyPoint.position.x,
                                               0.0f,
                                               RalleyPoint.position.z);
        //ProgressBar = new Image[2];
        ProgressBar[0] = ProgressBar[0].GetComponent<Image>();
        ProgressBar[1] = ProgressBar[1].GetComponent<Image>();
        DisableProgessBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBuilding)
        {
            CurrentBuildTime += Time.deltaTime;
            ProgressBar[1].fillAmount = CurrentBuildTime / BuildTime;
            if(CurrentBuildTime >= BuildTime)
            {
                CurrentBuildTime = 0.0f;
                isBuilding = false;
                ProduceWorker();
                DisableProgessBar();
            }
        }
    }
    public void ProduceWorker()
    {
        GameObject g = Instantiate(WorkerPrefab, SpawnPoint.position, Quaternion.identity) as GameObject;
        g.GetComponent<Worker>().OnSpawn(RalleyPoint.position);
    }

    public override void ClosetestResorucePatches()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, SphereRadius);
        foreach (Collider c in col)
        {
            if (c.gameObject.tag == "Mineral")
            {
                ResourcePatches.Add(c.gameObject);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    public void AddMinerals(int _add)
    {
        MineralCount += _add;
        PlayerHUD.UpdateMineralCountDisplay(_add);
    }

    public void OnCollisionEnter(Collision _col)
    {
        Worker w = _col.gameObject.GetComponent<Worker>();
        if (w && w.GetCarryAmount() > 0)
        {
            w.transform.LookAt(null);
            w.GetMyRBody().velocity = Vector3.zero;
            AddMinerals(w.GetCarryAmount());
            w.DetachPrefab();
            w.Move(w.GetTargetResource().transform.position);
        }
    }
 }
