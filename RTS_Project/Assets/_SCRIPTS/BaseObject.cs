using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public Sprite UnitIcon;
    public Sprite[] IconImages;
    public PlayerUI PlayerHUD;
    void Awake()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>();
        //IconImages = new Sprite[7];
    }
    // Use this for initialization
    void Start()
    {
        myType = OBJECT_TYPE.BASE_TYPE;
        PlayerHUD = PlayerHUD.GetComponent<PlayerUI>();
        IconImages = new Sprite[PlayerHUD.HUDButtons.Length];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHUDOnClick()
    {
        //set the huds icon to the player icon for selected unit
        if (PlayerHUD == null)
            return;
        PlayerHUD.UnitPicture.sprite = UnitIcon;
        PlayerHUD.SetButtons(false);
        for(int x = 0; x< IconImages.Length; x++)
            PlayerHUD.SetButtons(x, IconImages[x]);
    }

    public virtual void OnClick(RaycastHit _objClickedOn, bool _isAgressive = false)
    {
        Debug.Log("Didn't Override");
    }
}
