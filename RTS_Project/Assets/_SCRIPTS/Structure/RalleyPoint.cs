using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RalleyPoint : MonoBehaviour
{
    private GameObject myOwner;
    private Image RalleyIcon;
    public void TurnOnRalleyIcon() { RalleyIcon.enabled = true; }
    public void TurnOffRaalleyIcon() { RalleyIcon.enabled = false; }

    public void Init(GameObject _owner)
    {
        myOwner = _owner;
        RalleyIcon = GetComponentInChildren<Image>();
        RalleyIcon.enabled = false;
    }
}
