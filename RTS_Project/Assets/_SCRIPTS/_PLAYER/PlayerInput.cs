using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public Shader OnClickShader;
    private bool IsAgressive = false;
    private GameObject OBJ_Clicked;
    private GameObject LastObjClicked;
    public GameObject GetLastClicked() { return LastObjClicked; }
    private GameObject RalleyTransform;

    public enum KEYBOARD_STATE
    {
        NORMAL, ATTACK, PATROL, RALLEY
    };
    private KEYBOARD_STATE myKeyboardState;
    public void ChangeKeyboardState(KEYBOARD_STATE _s, GameObject _g = null)
    {
        myKeyboardState = _s;
        RalleyTransform = _g;
    }
    public GameObject GetCurrentClickedObject() { return OBJ_Clicked; }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myKeyboardState == KEYBOARD_STATE.RALLEY)
        {
            RalleyPoint r = RalleyTransform.GetComponent<Structure>().GetMyRalleyPoint();
            if (r == null)
                Debug.Log("problem");
            r.TurnOnRalleyIcon();
            r.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetButtonDown("Left Click"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 spot = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                    RalleyTransform.transform.position = spot;
                    myKeyboardState = KEYBOARD_STATE.NORMAL;
                    RalleyTransform = null;
                    return;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Left Click"))
                OnLeftClick();
            if (Input.GetButtonDown("Right Click"))
                OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.point.y < 0.0f)
                hit.point = new Vector3(hit.point.x, 0.0f, hit.point.z);
            Renderer r;
            BaseObject obj = hit.transform.gameObject.GetComponent<BaseObject>();
            if (obj != null)
                obj.UpdateHUDOnClick();
            if (LastObjClicked != null)
            {
                r = LastObjClicked.GetComponentInChildren<Renderer>();
                r.material.shader = Shader.Find("Standard");
            }
            if (obj.GetHighlightable())
            {
                LastObjClicked = obj.gameObject;
                r = LastObjClicked.GetComponentInChildren<Renderer>();
                r.material.shader = OnClickShader;
            }
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
