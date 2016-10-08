using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventCardUpdate : MonoBehaviour {

    public GameObject eventCard;
    private GameManager gameM;
    private Event curEvent;

	// Use this for initialization
	void Start () {
        gameM = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        NewEvent();
	}

    void NewEvent ()
    {
        curEvent = gameM.GetCurrentEvent();
        if (gameM)
        {
            if (curEvent.id != -1) {
                GameObject patateobject = Instantiate(eventCard, new Vector3(-1, 3, 0), Quaternion.identity) as GameObject;
                Text textM = patateobject.GetComponentInChildren<Text>();
                textM.text = "Yop \n" + "est";
                Destroy(patateobject, 5);
            }
            gameM = false;
            Debug.Log(curEvent.id);
        }
    }
}
