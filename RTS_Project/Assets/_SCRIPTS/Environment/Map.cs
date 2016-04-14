using UnityEngine;
using System.Collections;

public class Map : Environment
{


    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.ENVIRONMENT;
        myEType = ENVIRONMENT_TYPE.LEVEL;
        isHighlightable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnClick(RaycastHit _clickedOn, bool isAgressive = false)
    {
        //Unit gameUnit = _clickedOn.transform.gameObject.GetComponent<Unit>();
        //if (gameUnit != null)
        //{
        //    gameUnit.Move(_clickedOn.point);
        //}
    }

}
