using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CentralNew : MonoBehaviour {
   

    public class Card
    {
        public int type;
        public int attribute;
        public int value;

        public Card(int a, int b, int c)
        {
            type = a;
            attribute = b;
            value = c;
        }
    }
    public GameObject screen;
    public GameObject card_prefab;
    public GameObject soldier_prefab;
    public int econAvailable = 3;
    public int scienceAvailable = 3;
    public int armyAvailable = 3;
    public GameObject camera;
    public int wood, food, money, people;
    public int s_science, s_econ, s_army;
    public int a_atk, a_def, a_hp;

    //These are for setting up card
    public GameObject[] econCard;
    public GameObject[] scienceCard;
    public GameObject[] armyCard;
    public List<GameObject> econCardList = new List<GameObject>();
    public List<GameObject> armyCardList = new List<GameObject>();
    public List<GameObject> scienceCardList = new List<GameObject>();

    //The actual list of army
    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> armyList = new List<GameObject>();

    //temporary lsit use for everything
    public List<GameObject> tempList = new List<GameObject>();
    public List<GameObject> armyReserve = new List<GameObject>();

    //The list of 4 sides contains troops




   
    public int day;

    

	// Use this for initialization
	void Start () {
        econCard = new GameObject[5];
        scienceCard = new GameObject[5];
        armyCard = new GameObject[5];
        Init_game();
       
       
	}

    void Init_game()
    {

        //Init economy
        Init_Econ();
        

        //Init science
        Init_Science();

        //Init army
        Init_Army();
    }
	
    void Init_Army()
    {
        for (int i = 0; i < armyAvailable; i++)
        {
            armyCard[i] = null;
        }

        Vector3 card1 = new Vector3(2, 0, 1);
        GameObject instance = Instantiate(card_prefab, new Vector3(50, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        armyCard[0] = instance;

        card1 = new Vector3(2, 1, 1);
        instance = Instantiate(card_prefab, new Vector3(52, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        armyCard[1] = instance;

        card1 = new Vector3(2, 2, 1);
        instance = Instantiate(card_prefab, new Vector3(54, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        armyCard[2] = instance;
    }

    void Init_Science()
    {
        for (int i = 0; i < scienceAvailable; i++)
        {
            scienceCard[i] = null;
        }

        Vector3 card1 = new Vector3(1, 0, 1);
        GameObject instance = Instantiate(card_prefab, new Vector3(-50, -50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        scienceCard[0] = instance;

        card1 = new Vector3(1, 1, 1);
        instance = Instantiate(card_prefab, new Vector3(-48, -50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        scienceCard[1] = instance;

        card1 = new Vector3(1, 2, 1);
        instance = Instantiate(card_prefab, new Vector3(-46, -50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        scienceCard[2] = instance;
    }

   

    void Init_Econ()
    {
        for (int i = 0; i < econAvailable; i++)
        {
            econCard[i] = null;
        }

        Vector3 card1 = new Vector3(0, 0, 1);
        GameObject instance = Instantiate(card_prefab, new Vector3(-50, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        econCard[0] = instance;

        card1 = new Vector3(0, 1, 1);
        instance = Instantiate(card_prefab, new Vector3(-48, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        econCard[1] = instance;

        card1 = new Vector3(0, 2, 1);
        instance = Instantiate(card_prefab, new Vector3(-46, 50, 0), Quaternion.identity) as GameObject;
        instance.SendMessage("NewCard", card1);
        econCard[2] = instance;
    }

	// Update is called once per frame
	void Update () {
	    
	}

    public void NextDay()
    {
        //When next day button click, disable user control and set day and resource

        day++;

        //Set next day resources gain
        ResourcesGain();
        CheckArmy();

        //Send to the Army manager and get each of them to do their action
        //After they are done, the army manager will send to NextDayCont()
    }

    void ResourcesGain()
    {
        Tile_new tile_scr;
        for (int i = 0; i < 5; i++)
        {
            if (econCard[i] != null)
            {
                tile_scr = econCard[i].GetComponent<Tile_new>();
                if (tile_scr.card.attribute == 0)
                {
                    wood = wood + people*tile_scr.card.value;
                }
                else if (tile_scr.card.attribute == 1)
                {
                    food = food + people* tile_scr.card.value;
                }
                else
                {
                    money = money + people*  tile_scr.card.value;
                }
            }
            if(scienceCard[i] != null)
            {
                tile_scr = scienceCard[i].GetComponent<Tile_new>();
                if (tile_scr.card.attribute == 0)
                {
                    s_science = s_science + tile_scr.card.value;
                }
                else if (tile_scr.card.attribute == 1)
                {
                    s_econ = s_econ + tile_scr.card.value;
                }
                else
                {
                    s_army = s_army + tile_scr.card.value;
                }
            }
        }
    }

    void CheckArmy()
    {
         Tile_new tile_scr;
         for (int i = 0; i < 5; i++)
         {
             if (armyCard[i] != null)
             {
                 tile_scr = armyCard[i].GetComponent<Tile_new>();
                 if (tile_scr.card.attribute == 0)
                 {
                     a_atk =  tile_scr.card.value;
                 }
                 else if (tile_scr.card.attribute == 1)
                 {
                     a_def =  tile_scr.card.value;
                 }
                 else
                 {
                     a_hp = tile_scr.card.value;
                 }
             }
         }
    }

    public void OpenPack1(int tier)
    {
        //Debug.Log("OpenPack1");
        //Create new card
        Vector3 card1;
        GameObject instance;

        //Create a screen

       

        for (int i = 0; i < 3; i++)
        {
            card1 = CreateCard(tier);
            instance = Instantiate(card_prefab, new Vector3(-50, -50, 0), Quaternion.identity) as GameObject;
            instance.SendMessage("NewCard", card1);
            tempList.Add(instance);
            instance.transform.position = new Vector3(120 + i, 100, -5);
        }

        //Put these card at 120,100


        //Put these card in a tempCardList

        //change camera to them
        camera.transform.position = new Vector3(120, 100, -10);

    }

    public void SortingCard()
    {
        Tile_new tile_scr;
        for(int i = 0; i < tempList.Count; i++)
        {
            tile_scr = tempList[i].GetComponent<Tile_new>();
            tile_scr.OnMouseUp();
        }
        tempList.Clear();
    }

    public Vector3 CreateCard(int tier)
    {
        Vector3 card = new Vector3(0, 0, 0);
        card.x = Random.Range(0, 3);
        card.y = Random.Range(0, 3);
        int rd = Random.Range(0, 100);
        if (rd < 50)
        {
            if (tier == 1)
            {
                card.z = 1;
            }
            if (tier == 2)
            {
                card.z = 5;
            }
        }
        else if (rd < 30)
        {
            if (tier == 1)
            {
                card.z = 2;
            }
        }
        else
        {
            if (tier == 1)
            {
                card.z = 3;
            }
        }
        return card;
    }

    void ArmyManager()
    {
        //Send message to each army in the armylist

        
    }

    public void NextDayCont()
    {
        //Send to the Enemy Manager and get each one of them to do their action
        //After they are done, the enemy manager will send to NextDayCont2()
    }

    public void NextDayCont2()
    {
       //enable player to do next stuff
    }

    public void GoToEconomy()
    {
        camera.transform.position = new Vector3(-47, 50, -10);
    }

    public void GoToScience()
    {
        camera.transform.position = new Vector3(-47, -50, -10);
    }

    public void GoToArmy()
    {
        camera.transform.position = new Vector3(53, 50, -10);
        GameObject drag = GameObject.Find("ArmyReserved");
        drag.transform.position = new Vector3(60, 50, -1);
        drag.SendMessage("Setx", 60);
    }

    public void GoToCardMarket()
    {

        camera.transform.position = new Vector3(100, 100, -10);
    }

    public void Create_Troop()
    {

        CheckArmy();
        Vector3 soldier = new Vector3(a_atk, a_def, a_hp);
        GameObject instance = Instantiate(soldier_prefab, new Vector3(50, 50, 0), Quaternion.identity) as GameObject;
        //armyCard[0] = instance;
        armyReserve.Add(instance);
        instance.transform.parent = GameObject.Find("ArmyReserved").transform;
        instance.SendMessage("Parenting");

    }

    public void GoToArmySetting()
    {
        GameObject drag =  GameObject.Find("ArmyReserved");
        drag.transform.position = new Vector3(118,120,-1);
        drag.SendMessage("Setx", 118);


        camera.transform.position = new Vector3(120, 120, -10);
    }
   
    public void BackToTown()
    {
        camera.transform.position = new Vector3(0, 0, -10);
    }

    public void GoSouth()
    {
        camera.transform.position = new Vector3(0, -20, -10);
    }

    public void GoNorth()
    {
        camera.transform.position = new Vector3(0, 20, -10);
    }

    public void GoWest()
    {
        camera.transform.position = new Vector3(-20, 0, -10);
    }

    public void GoEast()
    {
        camera.transform.position = new Vector3(20, 0, -10);
    }

    public void WestArmy()
    {
        GameObject drag = GameObject.Find("West");
        drag.transform.position = new Vector3(-18, 0, -1);
        drag.SendMessage("Setx", -18);
    }

}
