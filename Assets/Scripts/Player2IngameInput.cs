using UnityEngine;
using System.Collections;

public class Player2IngameInput : MonoBehaviour {

    private int selectedMember = 0;
    private int[] actions = new int[4];

    public SpriteRenderer fleche;
    public SpriteRenderer check;

    public SpriteRenderer ArtCheck;
    public SpriteRenderer HackCheck;
    public SpriteRenderer GenCheck;
    public SpriteRenderer ProgCheck;

    // Use this for initialization
    void Start () {
        foreach (int x in actions)
            actions[x] = -1;
        check.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("BoutonAP2"))
        {
            //ART
            actions[selectedMember] = 1;
            switch (selectedMember)
            {
                case 0:
                    ArtCheck.enabled = true;
                    break;
                case 1:
                    GenCheck.enabled = true;
                    break;
                case 2:
                    ProgCheck.enabled = true;
                    break;
                case 3:
                    HackCheck.enabled = true;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetButtonDown("BoutonBP2"))
        {
            //PROGRAMMER
            actions[selectedMember] = 0;
            switch (selectedMember)
            {
                case 0:
                    ArtCheck.enabled = true;
                    break;
                case 1:
                    GenCheck.enabled = true;
                    break;
                case 2:
                    ProgCheck.enabled = true;
                    break;
                case 3:
                    HackCheck.enabled = true;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetButtonDown("BoutonXP2"))
        {
            //HACKER
            actions[selectedMember] = 2;
            switch (selectedMember)
            {
                case 0:
                    ArtCheck.enabled = true;
                    break;
                case 1:
                    GenCheck.enabled = true;
                    break;
                case 2:
                    ProgCheck.enabled = true;
                    break;
                case 3:
                    HackCheck.enabled = true;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetButtonDown("BoutonYP2"))
        {
            //DORMIR
            actions[selectedMember] = 3;
            switch (selectedMember)
            {
                case 0:
                    ArtCheck.enabled = true;
                    break;
                case 1:
                    GenCheck.enabled = true;
                    break;
                case 2:
                    ProgCheck.enabled = true;
                    break;
                case 3:
                    HackCheck.enabled = true;
                    break;
                default:
                    break;
            }
        }

        if (Input.GetButtonDown("BoutonStartP2"))
        {
            int cpt = 0;
            foreach (int x in actions)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                {
                    GameManager.Instance.setAction(actions, 1);
                    check.enabled = true;
                    fleche.enabled = false;
                    ArtCheck.enabled = false;
                    GenCheck.enabled = false;
                    ProgCheck.enabled = false;
                    HackCheck.enabled = false;
                    this.enabled = false;
                }
                cpt++;
            }
        }

        if (Input.GetAxis("XDpadP2") == 1)
        {
            //UP ARROW ARTISTE
            if (selectedMember != 0)
            {
                selectedMember = 0;
                fleche.transform.position = new Vector3((float)2, (float)5.2, 0);
            }
        }
        if (Input.GetAxis("XDpadP2") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            if (selectedMember != 2)
            {
                selectedMember = 2;
                fleche.transform.position = new Vector3((float)2.09, (float)3.15, 0);
            }
        }
        if (Input.GetAxis("YDpadP2") == 1)
        {
            //RIGHT ARROW GENERALISTE
            if (selectedMember != 1)
            {
                selectedMember = 1;
                fleche.transform.position = new Vector3((float)3.63, (float)4.26, 0);
            }
        }
        if (Input.GetAxis("YDpadP2") == -1)
        {
            //LEFT ARROW HACKER
            if (selectedMember != 3)
            {
                selectedMember = 3;
                fleche.transform.position = new Vector3((float)0.58, (float)4.26, 0);
            }
        }
    }

    public void resetActions()
    {
        actions[0] = -1;
        actions[1] = -1;
        actions[2] = -1;
        actions[3] = -1;
    }
}
