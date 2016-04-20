using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RalleyPoint : MonoBehaviour
{
    private GameObject myOwner;
    private Image RalleyIcon;
    public void TurnOnRalleyIcon() { RalleyIcon.enabled = true; }
    public void TurnOffRalleyIcon() { RalleyIcon.enabled = false; }
    public void TurnOnLine() { myLineRenderer.enabled = true; }
    public void TurnOffLine() { myLineRenderer.enabled = false; }
    public void UpdateMyLine()
    {
        vert[0] = transform.position;
        myLineRenderer.SetPositions(vert);
    }
    public void EnableHelpfulInfo()
    {
        TurnOnLine();
        TurnOnRalleyIcon();
    }
    public void DisableHelpfulInfo()
    {
        TurnOffLine();
        TurnOffRalleyIcon();
        UpdateMyLine();
    }
    private LineRenderer myLineRenderer;
    private Vector3[] vert = new Vector3[2];
    public void Init(GameObject _owner)
    {
        myOwner = _owner;
        RalleyIcon = GetComponentInChildren<Image>();
        RalleyIcon.enabled = false;
        myLineRenderer = GetComponent<LineRenderer>();
        vert[0] = transform.position;
        vert[1] = myOwner.transform.position;
        myLineRenderer.SetPositions(vert);
        myLineRenderer.enabled = false;
    }
}
