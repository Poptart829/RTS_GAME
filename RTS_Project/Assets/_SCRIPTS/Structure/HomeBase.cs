using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeBase : Structure
{
    private Rect resourceDisplay;
    private int MineralCount = 0;
    protected List<GameObject> ResourcePatches;
    public float SphereRadius = 30.0f;
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
    
    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.HOMEBASE;
        resourceDisplay = new Rect(Screen.width - 100, 10, 40, 40);
    }

    // Update is called once per frame
    void Update()
    {

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
    public void OnGUI()
    {
        string display = "Minerals " + MineralCount.ToString();
        GUI.Label(resourceDisplay, display);
    }

    public void AddMinerals(int _add)
    {
        MineralCount += _add;
    }
}
