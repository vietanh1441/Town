using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {

    public int attack, defense, hp;

    public GameObject parent_list;
    public Drag parent_scr;
    private Soldier soldier;
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject central;
    private CentralNew central_scr;
	// Use this for initialization
	void Start () {
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<CentralNew>();

	}
	
	// Update is called once per frame
    void Update()
    {
        
        



    }

    public void Parenting()
    {
       //  parent_scr;
        if (transform.parent != null)
        {
            parent_list = transform.parent.gameObject;
            parent_scr = parent_list.GetComponent<Drag>();
            parent_scr.theList.Add(gameObject);
            transform.localPosition = new Vector3(0, 0 - 0.03f * parent_scr.theList.IndexOf(gameObject), -1);
        }
        
    }

    void NewSoldier(Vector3 card_central)
    {
        attack = (int)card_central.x;
        defense = (int)card_central.y;
        hp = (int)card_central.z;
        
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
     }

    void OnMouseUp()
     {
        //Use rayhit to check
         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.01f, 1 << LayerMask.NameToLayer("Army"));
         if (hit.collider != null)
         {
             Debug.Log(hit.collider);
             transform.SetParent(hit.transform);
         }
         else
         {
             transform.SetParent(GameObject.Find("ArmyReserved").transform);
         }
         //transform.parent.gameObject.SendMessage("DoParent");
         //Parenting();
        //if hit, set it to parent and put it as parent list
     }
}
