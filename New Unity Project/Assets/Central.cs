using UnityEngine;
using System.Collections;

public class Central : MonoBehaviour {
    bool editor;
    public class Soldier
    {
        public int atk; 			//Minimum value for our Count class.
        public int def; 			//Maximum value for our Count class.
        public int hp;


        //Assignment constructor.
        public Soldier(int a, int d, int h)
        {
            atk = a;
            def = d;
            hp = h;
        }

        public void Modify(int a, int d, int h)
        {
            atk = a;
            def = d;
            hp = h;
        }
    }
    public GameObject camera;
    public Soldier melee = new Soldier(1, 1, 1);

    public GameObject currentList;
	// Use this for initialization
	void Start () {
        editor = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.I)&& editor == false)
        {
            OpenEditor();
            editor = true;
        }
        else if(Input.GetKeyDown(KeyCode.I)&& editor == true)
        {
            ClosedEditor();
            editor = false;
        }
	}

    void OpenEditor()
    {
        //Move camera to designated edit space
        Vector3 position = new Vector3(-48, -50, -10);
        camera.transform.position = position;
        Debug.Log("Called");
        //Create a list the same with the current list
        TileManager tile_scr = currentList.GetComponent<TileManager>();
        tile_scr.Editor();

    }

    void ClosedEditor()
    {
        Debug.Log("CalledClosing");
        //Saved this list to the current list 
        currentList.SendMessage("DisableEditingTemp");
        //Delete this list

    }
}
