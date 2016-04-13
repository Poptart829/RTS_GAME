using UnityEngine;
using System.Collections;

public class HomeBase : Structure
{
    private Rect resourceDisplay;
    private int MineralCount = 0;
	// Use this for initialization
	void Start ()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.HOMEBASE;
        ClosetestResorucePatches();

        resourceDisplay = new Rect(Screen.width - 100, 10, 40, 40);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public override void ClosetestResorucePatches()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, SphereRadius);
        foreach(Collider c in col)
        {
            if(c.gameObject.tag == "Mineral")
            {
                ResourcePatches.Add(c.gameObject);
            }
        }
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
