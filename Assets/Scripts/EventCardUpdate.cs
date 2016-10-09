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
        if (gameM.newT)
        {
            if (curEvent.id != -1) {
                GameObject patateobject = Instantiate(eventCard, new Vector3(-1, 3, 0), Quaternion.identity) as GameObject;
                Text[] textM = patateobject.GetComponentsInChildren<Text>();
                textM[0].text = curEvent.FlavorText + "\n ";
                textM[1].text = "Art: ";
                textM[1].text += definitionEvent((int)(curEvent.teamArtEffect*100)) + "\n";
                textM[1].text += "Programmation: ";
                textM[1].text += definitionEvent((int)(curEvent.teamProgEffect * 100)) + "\n";
                textM[1].text += "Salt: ";
                textM[1].text += definitionEvent((int)(curEvent.teamSaltEffect * 100)) + "\n";
                textM[1].text += "Sommeil: ";
                textM[1].text += definitionEvent((int)(curEvent.teamSleepEffect * 100));
                Destroy(patateobject, 5);
            }
            gameM.newT = false;
            Debug.Log(curEvent.id);
        }
    }

    string definitionEvent(int impact) {
        Debug.Log(impact);
        switch (impact)
        {
            case 1: return "positivement";
            case 25: return "fortement";
            case 50: return "moyennement";
            case  75: return "peu";
            case 100: return "aucunement";
            case 125: if (curEvent.teamSaltEffect == 1.25)
                    return "fortement";
                else
                    return "positivement";
            default: return "peu";
        }
    }
}
