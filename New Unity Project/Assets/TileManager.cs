using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TileManager : MonoBehaviour {
    public List<GameObject> tileList = new List<GameObject>();
    public GameObject initialTile;
    public List<GameObject> tempList = new List<GameObject>();
    public GameObject currentPlayer;
    //This is used to create pre-determine list
    public List<GameObject> premade = new List<GameObject>();
	// Use this for initialization
	void Start () {
        SpawnTile();
        

	}

    
    //Instantiate every tile

    //This need to be fixed. The central should be the one that create the Tile at the start, 
    //then the TileManager just simply used the tile instead of creating a new tile every time

    //Or, this could be great during startup, as a way to save, but the program need to be fixed as 
    //"Moving tile around" instead of cloning.
    void SpawnTile()
    {
        GameObject instance = Instantiate(initialTile, new Vector3(transform.position.x, transform.position.y , 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(transform);
        tileList.Add(instance);

        for(int i = 0; i < premade.Count; i++)
        {
            instance = Instantiate(premade[i], new Vector3(transform.position.x, transform.position.y+i+1, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(transform);
            tileList.Add(instance);
        }
        premade.Clear();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

  

   
    //Check what tile is at position
    GameObject CheckTile(int position)
    {
        return tileList[position];
    }

    public void Editor()
    {
        //Create new list at -50,-50,-10
        Destroy(currentPlayer);

        for (int i = 1; i < tileList.Count; i++)
        {
            
            tileList[i].transform.position = new Vector3(-50, -50 + i, 0f);
           // instance.transform.SetParent(transform);
            tempList.Add(tileList[i]);
        }

        Invoke("EnableEditingTemp", 1);
    }

    public void EnableEditingTemp()
    {
        //Enable these tile to be edited
        for (int i = 0; i < tempList.Count; i++)
        {
            tempList[i].SendMessage("EnableEditing", gameObject);
            
        }
    }

   public void DisableEditingTemp()
    {
        for (int i = 0; i < tempList.Count; i++)
        {
            tempList[i].SendMessage("DisableEditing", gameObject);

        }
       
       //save temp list to tileList
       
            tileList.Clear();

            GameObject instance = Instantiate(initialTile, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(transform);
            tileList.Add(instance);
   
       for(int i = 0; i < tempList.Count; i++)
        {
            tileList.Add(tempList[i]);
            tempList[i].transform.position = new Vector3(transform.position.x, transform.position.y + i + 1, 0f);
        }

       // SpawnTile();
       //camera back
    }
}
