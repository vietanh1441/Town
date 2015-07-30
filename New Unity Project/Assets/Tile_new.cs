using UnityEngine;
using System.Collections;

public class Tile_new : MonoBehaviour {
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
    public GameObject bg, val;
    public Sprite[] bg_sprite;
    public Sprite[] att_sprite;
    public Sprite[] val_sprite;
    public int econAvailable;
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject parent_list;

    public Card card;
    public GameObject central;
    public CentralNew tile_scr;
	// Use this for initialization
	void Start () {
        central = GameObject.Find("Central");
        tile_scr = central.GetComponent<CentralNew>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void NewCard(Vector3 card_central)
    {
        card = new Card((int)card_central.x, (int)card_central.y, (int)card_central.z);
        if (card_central.x == 0)
        {
            parent_list = GameObject.Find("EconCardList");
        }
        if(card_central.x == 1)
        {
            parent_list = GameObject.Find("ScienceCardList");
        }
        if(card_central.x == 2)
        {
            parent_list = GameObject.Find("ArmyCardList");
        }
        gameObject.GetComponent<SpriteRenderer>().sprite =  bg_sprite[(int)card_central.x];
        bg.GetComponent<SpriteRenderer>().sprite = att_sprite[(int)card_central.y];
        val.GetComponent<SpriteRenderer>().sprite = val_sprite[(int)card_central.z-1];
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }



    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (card.type == 0)
        {
            if (transform.position.x == -50 && transform.position.y == 50)
            {
                tile_scr.econCard[0] = null;
            }
            else if (transform.position.x == -48 && transform.position.y == 50)
            {
                tile_scr.econCard[1] = null;
            }
            else if (transform.position.x == -46 && transform.position.y == 50)
            {
                tile_scr.econCard[2] = null;
            }

            if (tile_scr.econCardList.Contains(gameObject))
            {
                tile_scr.econCardList.Remove(gameObject);
            }
        }
        else if (card.type == 1)
        {
            if (transform.position.x == -50 && transform.position.y == -50)
            {
                tile_scr.scienceCard[0] = null;
            }
            else if (transform.position.x == -48 && transform.position.y == -50)
            {
                tile_scr.scienceCard[1] = null;
            }
            else if (transform.position.x == -46 && transform.position.y == -50)
            {
                tile_scr.scienceCard[2] = null;
            }

            if (tile_scr.scienceCardList.Contains(gameObject))
            {
                tile_scr.scienceCardList.Remove(gameObject);
            }
        }
        else if (card.type == 2)
        {
            if (transform.position.x == 50 && transform.position.y == 50)
            {
                tile_scr.armyCard[0] = null;
            }
            else if (transform.position.x == 52 && transform.position.y == 50)
            {
                tile_scr.armyCard[1] = null;
            }
            else if (transform.position.x == 54 && transform.position.y == 50)
            {
                tile_scr.armyCard[2] = null;
            }

            if (tile_scr.armyCardList.Contains(gameObject))
            {
                tile_scr.armyCardList.Remove(gameObject);
            }
        }
            //When mouse release, check its coordinate. If its x > -46, then delete it from templist 
       
    }

    public void OnMouseUp()
    {

        if (card.type == 0)
        {
            if (transform.position.y > 51 || transform.position.y < 49)
            {
                //tile_scr.econCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the econcardList
                tile_scr.econCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.econCardList.Count, parent_list.transform.position.y, -1);
            }
            else if (transform.position.x > -51 && transform.position.x < -45)
            {


                //remove object from econcardlist
                tile_scr.econCardList.Remove(gameObject);
                //remove parent
                transform.parent = null;
                //Add to econCard
                //tile_scr.econCard.Add(gameObject);
                int i = 0;
                if (transform.position.x > -51 && transform.position.x < -49)
                {
                    i = 0;
                }
                else if (transform.position.x > -49 && transform.position.x < -47)
                {
                    i = 1;
                }
                else if (transform.position.x > -47 && transform.position.x < -45)
                {
                    i = 2;
                }


                if (tile_scr.econCard[i] == null)
                {
                    tile_scr.econCard[i] = gameObject;
                    transform.position = new Vector3(-50 + 2 * i, 50, 0);
                }
                else
                {
                    tile_scr.econCard[i].transform.SetParent(parent_list.transform);
                    tile_scr.econCardList.Add(tile_scr.econCard[i]);
                    tile_scr.econCard[i].transform.position = new Vector3(parent_list.transform.position.x + tile_scr.econCardList.Count, parent_list.transform.position.y, -1);
                    tile_scr.econCard[i] = gameObject;
                    transform.position = new Vector3(-50 + 2 * i, 50, 0);
                }


            }
            else
            {
                // tile_scr.econCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the econcardList
                tile_scr.econCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.econCardList.Count, parent_list.transform.position.y, -1);
            }
            //Check if delete, i.e. its x > 46

            //if delete, fix the current econCard and redraw 

        }

            //****************************
            //******FOR SCIENCE***********
            //****************************
        else if (card.type == 1)
        {
            if (transform.position.y > -49 || transform.position.y < -51)
            {
                //tile_scr.econCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the econcardList
                tile_scr.scienceCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.scienceCardList.Count, parent_list.transform.position.y, -1);
            }
            else if (transform.position.x > -51 && transform.position.x < -45)
            {


                //remove object from scienceCardlist
                tile_scr.scienceCardList.Remove(gameObject);
                //remove parent
                transform.parent = null;
                //Add to scienceCard
                //tile_scr.scienceCard.Add(gameObject);
                int i = 0;
                if (transform.position.x > -51 && transform.position.x < -49)
                {
                    i = 0;
                }
                else if (transform.position.x > -49 && transform.position.x < -47)
                {
                    i = 1;
                }
                else if (transform.position.x > -47 && transform.position.x < -45)
                {
                    i = 2;
                }


                if (tile_scr.scienceCard[i] == null)
                {
                    tile_scr.scienceCard[i] = gameObject;
                    transform.position = new Vector3(-50 + 2 * i, -50, 0);
                }
                else
                {
                    tile_scr.scienceCard[i].transform.SetParent(parent_list.transform);
                    tile_scr.scienceCardList.Add(tile_scr.scienceCard[i]);
                    tile_scr.scienceCard[i].transform.position = new Vector3(parent_list.transform.position.x + tile_scr.scienceCardList.Count, parent_list.transform.position.y, -1);
                    tile_scr.scienceCard[i] = gameObject;
                    transform.position = new Vector3(-50 + 2 * i, -50, 0);
                }


            }
            else
            {
                // tile_scr.scienceCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the scienceCardList
                tile_scr.scienceCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.scienceCardList.Count, parent_list.transform.position.y, -1);
            }
            //Check if delete, i.e. its x > 46

            //if delete, fix the current scienceCard and redraw 

        }

        /************************
         * ****FOR THE HORDE*****
         * **********************/
        else if (card.type == 2)
        {
            if (transform.position.y < 49 || transform.position.y > 51)
            {
                //tile_scr.econCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the econcardList
                tile_scr.armyCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.armyCardList.Count, parent_list.transform.position.y, -1);
            }
            else if (transform.position.x > 49 && transform.position.x < 55)
            {


                //remove object from armyCardlist
                tile_scr.armyCardList.Remove(gameObject);
                //remove parent
                transform.parent = null;
                //Add to armyCard
                //tile_scr.armyCard.Add(gameObject);
                int i = 0;
                if (transform.position.x > 49 && transform.position.x < 51)
                {
                    i = 0;
                }
                else if (transform.position.x > 51 && transform.position.x < 53)
                {
                    i = 1;
                }
                else if (transform.position.x > 53 && transform.position.x < 55)
                {
                    i = 2;
                }


                if (tile_scr.armyCard[i] == null)
                {
                    tile_scr.armyCard[i] = gameObject;
                    transform.position = new Vector3(50 + 2 * i, 50, 0);
                }
                else
                {
                    tile_scr.armyCard[i].transform.SetParent(parent_list.transform);
                    tile_scr.armyCardList.Add(tile_scr.armyCard[i]);
                    tile_scr.armyCard[i].transform.position = new Vector3(parent_list.transform.position.x + tile_scr.armyCardList.Count, parent_list.transform.position.y, -1);
                    tile_scr.armyCard[i] = gameObject;
                    transform.position = new Vector3(50 + 2 * i, 50, 0);
                }


            }
            else
            {
                // tile_scr.armyCard.Remove(gameObject);
                transform.SetParent(parent_list.transform);
                //Add into the armyCardList
                tile_scr.armyCardList.Add(gameObject);
                //move it to the appropriate card list
                transform.position = new Vector3(parent_list.transform.position.x + tile_scr.armyCardList.Count, parent_list.transform.position.y, -1);
            }
            //Check if delete, i.e. its x > 46

            //if delete, fix the current armyCard and redraw 

        }
    }
}
