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
}
