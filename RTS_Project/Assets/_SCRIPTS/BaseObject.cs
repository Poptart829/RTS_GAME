using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour
{
    public enum OBJECT_TYPE
    {
        BASE_TYPE, STRUCUTRE, RESOURCE, UNIT, ENVIRONMENT
    };
    public OBJECT_TYPE myType;
    protected Rigidbody myRigidBody;
    public Rigidbody GetMyRBody() { return myRigidBody; }
    protected bool isMoveable = false;
    public bool GetMoveable() { return isMoveable; }
    protected bool isHighlightable = true;
    public bool GetHighlightable() { return isHighlightable; }
    void Awake()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start ()
    {
        myType = OBJECT_TYPE.BASE_TYPE;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public virtual void OnClick(RaycastHit _objClickedOn, bool _isAgressive = false)
    {
        Debug.Log("Didn't Override");
    }
}
