using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    public bool hover;
    public int nationNum;
    public GameObject hex;
    private Hexagon hexagon;

	// Use this for initialization
	void Start () {
        nationNum = UIManager.turnNumber;
        name = "Castle " + UIManager.selectedCountry;
        transform.SetParent(UIManager.selectedCountry.transform);
	}
	
	// Update is called once per frame
	void Update () {
        if (hover && UIManager.hoverMode)
        {
            this.transform.position = FindObjectOfType<Mouse>().transform.position;
        }
	}

    public void Place(GameObject g){
        hex = g;
        hexagon = g.GetComponent<Hexagon>();
        hexagon.hasCastle = true;
        this.transform.parent.GetComponent<Country>().UpdateGuard();
        this.transform.parent.GetComponent<Country>().capital.EditFlag();
        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Destroy(this.GetComponent<CircleCollider2D>());
        Vector3 pos = hex.transform.position;
        this.transform.position = pos;
        Mouse.ResetViableHexagons();
    }
}
