using UnityEngine;
using System.Collections;

public class PlayerStore : MonoBehaviour
{
    public PlayerUI myPlayerUI;
    // Use this for initialization
    void Start()
    {
        myPlayerUI = myPlayerUI.GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool SpendMoney(int _amount)
    {
        if (myPlayerUI.GetTotalMinerals() > _amount)
        {
            myPlayerUI.UpdateMineralCountDisplay(-_amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DEBUGAddMoney(int _amount)
    {
        myPlayerUI.UpdateMineralCountDisplay(_amount);
    }

    public void DEBUGSubtractMoney(int _amount)
    {
        myPlayerUI.UpdateMineralCountDisplay(-_amount);
        if (myPlayerUI.GetTotalMinerals() < 0)
        {
            myPlayerUI.SetTotalMineals(0);
        }
    }

}
