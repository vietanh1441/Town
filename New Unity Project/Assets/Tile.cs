using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject camera;
    public int value;
    public bool editing;
    public int TileType;
    public int speed = 5;

    public TileManager tile_scr;
    /*
        0  Combat,
        1 Science,
        2 Worker,
    */

    public int Combat;
    /*
        0 Atk,
        1 Def,
        2 Hp,
    */
    

    public int Science;
    /*
        0 Economy,
        1 Army,
        2 Techonology,
    };*/

    public int Work;
    /*
     *0 Wood
     *1 Gold
     *2 Wine
     */

	// Use this for initialization
	void Start () {
       // editing = false;
        speed = 5;
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	    if(editing == true)
        {
            if (tile_scr.tempList.Contains(gameObject))
            {
                int y = tile_scr.tempList.IndexOf(gameObject) - 50;
                Vector3 goPosition = new Vector3(-50, y, 0);
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, goPosition, step);
            }
        }
	}

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }



    void OnMouseDrag()
    {
        if(editing == true)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

            //When mouse release, check its coordinate. If its x > -46, then delete it from templist 
        }
    }

    void OnMouseUp()
    {
        if(transform.position.x > -48)
        {
            tile_scr.tempList.Remove(gameObject);
        }
        else if(transform.position.y > -51)
        {
            int index = (int)transform.position.y + 50;
            if (tile_scr.tempList.Contains(gameObject))
            {
                tile_scr.tempList.Remove(gameObject);
                tile_scr.tempList.Insert(index, gameObject);
            }
            else
            {
                tile_scr.tempList.Insert(index, gameObject);
            }
        }
        //Check if delete, i.e. its x > 46

        //if delete, fix the current templist and redraw 

        
    }

    void EnableEditing(GameObject manager)
    {
        tile_scr = manager.GetComponent<TileManager>();
        editing = true;
    }

    void DisableEditing()
    {
        editing = false;
    }

}
