using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Man : MonoBehaviour {

    public GameObject list_obj;
    public TileManager list_scr;
    public int position;
    public Vector3 goPosition;
    public float speed;
    public GameObject tile;

    public GameObject uiText;
    

    public int atk, def, hp;
    public int temp_hp;

    //Different type for soldier:
    //1 = front line
    //2 = long range
    //3 = siege
    //4 = flank
    //5 = bomber
    //6 = air-fighter
    //7 = support
    public int type;


	// Use this for initialization
	void Start () {
        
        list_scr = list_obj.GetComponent<TileManager>();
        position = 0;
        Invoke("Go", 2);
        uiText.GetComponent<Text>().text = "";
	}
	
	// Update is called once per frame
	void Update () {
        goPosition.z = -1;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goPosition, step);
	}
    void Go()
    {
        position = position + ThrowDice();
        if(position >= list_scr.tileList.Count-1)
        {
            position = list_scr.tileList.Count-1;
        }
        else
        {
            Invoke("Go", 5);
        }
        tile =  list_scr.tileList[position] ;
        
        goPosition = tile.transform.position;

        TileWork(tile);
    }

    void TileWork(GameObject tile)
    {
        Tile tile_scr = tile.GetComponent<Tile>();
        //error checking
        if(tile_scr.TileType == 0)
        {
            if(tile_scr.Combat == 0)
            {
                atk = atk + tile_scr.value;
                UIText("atk + " + tile_scr.value);
            }
            if (tile_scr.Combat == 1)
            {
                 def = def + tile_scr.value;
                 UIText("def + " + tile_scr.value);
            }
            if (tile_scr.Combat == 2)
            {
                hp = hp + tile_scr.value;
                UIText("hp + " + tile_scr.value);
            }
        }
    }

    void UIText(string s)
    {
        uiText.GetComponent<Text>().text = s;
    }


    int ThrowDice()
    {
        int rand = Random.Range(0, 6);

        if(rand == 0)
        {
            return 1;
        }
        if(rand == 1 || rand == 2)
        {
            return 2;
        }
        if(rand == 3 || rand == 4)
        {
            return 3;
        }
        if(rand == 5)
        {
            return 4;
        }

        return 0;
    }
}
