using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //the text that correlates to the number next to Minerals :
    public Text MineralCountDisplay;
    //total number of minerals mined by the player
    private int TotalMinerals = 0;
    // Use this for initialization
    public Image UnitPicture;
    public Image[] Icons;
    public Button[] HUDButtons;
    public Sprite EmptyIcon;
    private PlayerInput pInput;

    public delegate void ProduceUnitDelegate();
    public ProduceUnitDelegate myProduceUnit;

    void Start()
    {
        for (int x = 0; x < Icons.Length; x++)
            Icons[x] = Icons[x].GetComponent<Image>();
        for (int x = 0; x < HUDButtons.Length; x++)
            HUDButtons[x] = HUDButtons[x].GetComponent<Button>();
        ResetIcons();
        pInput = GameObject.Find("PlayerInput").GetComponent<PlayerInput>();
        if (pInput == null)
            Debug.Log("player ui -> pinput is null");
    }
    public void ResetIcons()
    {
        foreach (Image i in Icons)
            i.sprite = EmptyIcon;
    }

    public void SetButtons(bool _b)
    {
        foreach (Button b in HUDButtons)
            b.gameObject.SetActive(_b);
    }
    public void SetButtons(int _who, Sprite _img)
    {
        HUDButtons[_who].gameObject.SetActive(true);
        Icons[_who].sprite = _img;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMineralCountDisplay(int _amount)
    {
        TotalMinerals += _amount;
        MineralCountDisplay.text = TotalMinerals.ToString();
    }

    public string GetCurrentMineralDisplayText()
    {
        return MineralCountDisplay.text;
    }

    public void SpawnUnit()
    {
        GameObject clickedOn = pInput.GetLastClicked();
        if (clickedOn)
        {
            Structure s = clickedOn.GetComponent<Structure>();
            if (s == null)
            {
                Debug.Log("hey spawn unit() there is no s : " + clickedOn.gameObject.name);
                return;
            }
            switch (s.myStructType)
            {
                case Structure.STRUCT_TYPE.HOMEBASE:
                    HomeBase hb = clickedOn.GetComponent<HomeBase>();
                    //myProduceUnit = hb.ProduceWorker;
                    if (hb.GetIsBuilding() == false)
                        hb.SetIsBuilding(true, hb.GetWorkerBuildTime());
                    break;
                case Structure.STRUCT_TYPE.RAX:
                    break;
                case Structure.STRUCT_TYPE.FACTORY:
                    break;
                case Structure.STRUCT_TYPE.STARPORT:
                    break;
                default:
                    break;
            }
            // myProduceUnit();
        }
    }
}
