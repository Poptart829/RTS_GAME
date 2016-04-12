using UnityEngine;
using System.Collections;

public class Mineral : Resource
{
    public int MineralCap = 500;
    public float MiningRate = 0.5f;
    public int NumMiners = 2;

    private GameObject ClosetBase;
    private GameObject[] baseList;
    [Header("DebugInfo")]
    public bool ShowDebugLines = true;
    // Use this for initialization
    void Start()
    {
        baseList = GameObject.FindGameObjectsWithTag("Base");
        float shortestDistance = float.MaxValue;
        foreach (GameObject obj in baseList)
        {
            float distance = (transform.position - obj.transform.position).magnitude;
            if (distance < shortestDistance)
                ClosetBase = obj;
        }
        myType = OBJECT_TYPE.RESOURCE;
        myRType = RESOURCE_TYPE.MINERAL;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowDebugLines)
        {
            foreach (GameObject obj in baseList)
            {
                if (obj == ClosetBase)
                    Debug.DrawLine(transform.position, obj.transform.position, Color.red);
                else
                    Debug.DrawLine(transform.position, obj.transform.position, Color.black);
            }
        }

    }
}
