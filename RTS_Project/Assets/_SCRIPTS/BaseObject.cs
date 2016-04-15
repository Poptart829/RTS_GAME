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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHUDOnClick()
    {
        if (IconImages.Length > 0)
            for (int x = 0; x < IconImages.Length; x++)
            {
                if (IconImages[x] != null)
                {
                    PlayerHUD.Icons[x].sprite = IconImages[x];
                }
            }
        else
        {
            if (PlayerHUD != null)
                PlayerHUD.ResetIcons();
        }
    }

    public virtual void OnClick(RaycastHit _objClickedOn, bool _isAgressive = false)
    {
        Debug.Log("Didn't Override");
    }
}
