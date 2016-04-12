using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private bool IsAgressive = false;
    GameObject OBJ_Clicked;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50000000, Color.red);
            if (Physics.Raycast(ray, out hit))
            {
                BaseObject obj = hit.transform.gameObject.GetComponent<BaseObject>();
                if (obj)
                {
                    BaseObject.OBJECT_TYPE type = obj.myType;
                    Debug.Log(type);
                    switch (type)   
                    {
                        case BaseObject.OBJECT_TYPE.BASE_TYPE:
                            Debug.Log("DEFINE BASE TYPE");
                            break;
                        case BaseObject.OBJECT_TYPE.STRUCUTRE:
                            Debug.Log(obj.GetComponent<Structure>().myStructType);
                            break;
                        case BaseObject.OBJECT_TYPE.UNIT:
                            Debug.Log(obj.GetComponent<Unit>().myUnitType);
                            break;
                        case BaseObject.OBJECT_TYPE.ENVIRONMENT:
                            Debug.Log(obj.GetComponent<Environment>().myEType);
                            break;
                        case BaseObject.OBJECT_TYPE.RESOURCE:
                            Debug.Log(obj.GetComponent<Resource>().myRType);
                            break;
                        default:
                            break;
                    }
                }
                OBJ_Clicked = hit.transform.gameObject;
                //Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
