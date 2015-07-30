using UnityEngine;
using System.Collections;

public class Button_new : MonoBehaviour {
    public string hit;
    private GameObject central;
    private CentralNew central_scr;
    
	// Use this for initialization
	void Start () {
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<CentralNew>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Invoke(hit,0.1f);
    }

    void GoBack()
    {
        central_scr.SortingCard();
        central_scr.GoToCardMarket();
    }

    void Buy1()
    {
        Debug.Log("Buy1");
        //Check money
        if (central_scr.money > 200)
        {
            central_scr.money = central_scr.money - 200;
            //Do Buying stuff
            central_scr.OpenPack1(1);
        }
    }

   
    void Buy2()
    {

    }

    void Buy3()
    {

    }

    void CreateTroop()
    {
        central_scr.Create_Troop();
    }

    //4 button, when click, , move the according drag into position, while make the other 3 move to other place
    void North()
    {
        GameObject.Find("North").SendMessage("Readjust", new Vector3(125, 120, -1));
        GameObject.Find("South").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("West").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("East").SendMessage("Readjust", new Vector3(140, 120, -1));

    }

    void South()
    {
        GameObject.Find("South").SendMessage("Readjust", new Vector3(125, 120, -1));
        GameObject.Find("North").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("West").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("East").SendMessage("Readjust", new Vector3(140, 120, -1));
    }

    void East()
    {
        GameObject.Find("East").SendMessage("Readjust", new Vector3(125, 120, -1));
        GameObject.Find("South").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("West").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("North").SendMessage("Readjust", new Vector3(140, 120, -1));
    }

    void West()
    {
        GameObject.Find("West").SendMessage("Readjust", new Vector3(125, 120, -1));
        GameObject.Find("South").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("North").SendMessage("Readjust", new Vector3(140, 120, -1));
        GameObject.Find("East").SendMessage("Readjust", new Vector3(140, 120, -1));
    }

    public void GoToEconomy()
    {
        central_scr.GoToEconomy();
    }

    public void GoToScience()
    {
        central_scr.GoToScience();
    }

    public void GoToArmy()
    {
        central_scr.GoToArmy();
    }

    public void GoToCardMarket()
    {
        central_scr.GoToCardMarket();
    }

    public void GoToArmySetting()
    {
        central_scr.GoToArmySetting();
    }

    public void BackToTown()
    {
        central_scr.BackToTown();
    }

    public void GoNorth()
    {
        central_scr.GoNorth();
    }

    public void GoSouth()
    {
        central_scr.GoSouth();
    }

    public void GoWest()
    {
        central_scr.GoWest();
    }

    public void GoEast()
    {
        central_scr.GoEast();
    }

    public void WestArmy()
    {
        central_scr.WestArmy();
    }
}
