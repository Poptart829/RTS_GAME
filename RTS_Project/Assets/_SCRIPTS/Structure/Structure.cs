using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Structure : BaseObject
{
    public GameObject RalleyGameObject;
    protected RalleyPoint myRalleyPoint;
    public RalleyPoint GetMyRalleyPoint() { return myRalleyPoint; }
    public Transform SpawnPoint;
    protected bool isBuilding;
    protected float BuildTime;
    public void SetIsBuilding(bool _b, float _buildTimeForUnit)
    {
        EnableProgressBar();
        isBuilding = _b;
        BuildTime = _buildTimeForUnit;
    }
    public bool GetIsBuilding()
    {
        return isBuilding;
    }
    public enum STRUCT_TYPE
    {
        DEFAULT, MAP, HOMEBASE, RAX, FACTORY, STARPORT
    };

    public STRUCT_TYPE myStructType;
    public Image[] ProgressBar;
    // Use this for initialization
    void Start ()
    {
        myType = OBJECT_TYPE.STRUCUTRE;
        myStructType = STRUCT_TYPE.DEFAULT;
        ProgressBar = new Image[2];
        ProgressBar[0] = ProgressBar[0].GetComponent<Image>();
        ProgressBar[1] = ProgressBar[1].GetComponent<Image>();
        DisableProgessBar();
        //myRalleyPoint = RalleyGameObject.GetComponent<RalleyPoint>();
        //myRalleyPoint.Init(gameObject);
	}
	public void DisableProgessBar()
    {
        foreach (Image i in ProgressBar)
            i.gameObject.SetActive(false);
    }
    public void EnableProgressBar()
    {
        foreach (Image i in ProgressBar)
            i.gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update ()
    {
	
	}



    virtual public void ClosetestResorucePatches()
    {

    }
}
