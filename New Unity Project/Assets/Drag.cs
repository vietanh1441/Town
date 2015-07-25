using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour {
    private Vector3 offset;
    private Vector3 screenPoint;
    public float ypos;
    public float xpos;
    public List<GameObject> theList = new List<GameObject>();
    public int dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
       
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
     }

    void OnMouseDrag()
    {
    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (dir == 0)
        {
            curPosition.y = ypos;
        }
        else if (dir == 1)
        {
            curPosition.x = xpos;
        }
        transform.position = curPosition;
    }

    void Setx(float x)
    {
        xpos = x;
    }

    void DoParent()
    {
        for(int i = 0; i < theList.Count; i++)
        {
            theList[i].SendMessage("Parenting");
        }
    }
}
