using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private bool IsAgressive = false;
    GameObject OBJ_Clicked;
    private int RayDistance = 50000000;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Left Click"))
        {
            OnLeftClick();
        }
        if (Input.GetButtonDown("Right Click"))
        {
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            BaseObject obj = hit.transform.gameObject.GetComponent<BaseObject>();
            if (obj.GetMoveable())
            {
                OBJ_Clicked = obj.gameObject;
            }
            else
            {
                OBJ_Clicked = null;
            }
            if (obj)
            {
                BaseObject.OBJECT_TYPE type = obj.myType;
                switch (type)
                {
                    case BaseObject.OBJECT_TYPE.BASE_TYPE:
                        break;
                    case BaseObject.OBJECT_TYPE.STRUCUTRE:
                        break;
                    case BaseObject.OBJECT_TYPE.UNIT:
                        break;
                    case BaseObject.OBJECT_TYPE.ENVIRONMENT:
                        obj.GetComponent<Environment>().OnClick(hit);
                        break;
                    case BaseObject.OBJECT_TYPE.RESOURCE:
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.blue);
        if (Physics.Raycast(ray, out hit))
        {
            if (OBJ_Clicked)
            {
                Unit unitClicked = OBJ_Clicked.GetComponent<Unit>();
                switch (unitClicked.myUnitType)
                {
                    case Unit.UNIT_TYPE.WORKER:
                        OBJ_Clicked.GetComponent<Unit>().MakeDecision(hit); 
                        break;
                    case Unit.UNIT_TYPE.ATT_UNIT1:
                        break;
                    case Unit.UNIT_TYPE.ATT_UNIT2:
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
