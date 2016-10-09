using UnityEngine;
using System.Collections;

public class Player1IngameInput : MonoBehaviour {

    private int selectedMember = 0;
    private int[] actions = new int[4];

    public SpriteRenderer fleche;
    public SpriteRenderer check;

    // Use this for initialization
    void Start () {
        foreach (int x in actions)
            actions[x] = -1;
        check.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //INPUTS PLAYER 1
        if (Input.GetButtonDown("BoutonAP1"))
        {
            //ART
            actions[selectedMember] = 1;
        }
        if (Input.GetButtonDown("BoutonBP1"))
        {
            //PROGRAMMER
            actions[selectedMember] = 0;
        }
        if (Input.GetButtonDown("BoutonXP1"))
        {
            //HACKER
            actions[selectedMember] = 2;
        }
        if (Input.GetButtonDown("BoutonYP1"))
        {
            //DORMIR
            actions[selectedMember] = 3;
        }

        if (Input.GetButtonDown("BoutonStartP1"))
        {
            int cpt = 0;
            foreach(int x in actions)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                {
                    GameManager.Instance.setAction(actions, 0);
                    check.enabled = true;
                }
                cpt++;
            }
        }

        if (Input.GetAxis("XDpadP1") == 1)
        {
            //UP ARROW ARTISTE
            if (selectedMember != 0)
            {
                selectedMember = 0;
                fleche.transform.position = new Vector3((float)-3.35, (float)5.16, 0);
            }
        }
        if (Input.GetAxis("XDpadP1") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            if (selectedMember != 2)
            {
                selectedMember = 2;
                fleche.transform.position = new Vector3((float)-3.27, (float)3.15, 0);
            }
        }
        if (Input.GetAxis("YDpadP1") == 1)
        {
            //RIGHT ARROW GENERALISTE
            if (selectedMember != 1)
            {
                selectedMember = 1;
                fleche.transform.position = new Vector3((float)-1.73, (float)4.14, 0);
            }
        }
        if (Input.GetAxis("YDpadP1") == -1)
        {
            //LEFT ARROW HACKER
            if (selectedMember != 3)
            {
                selectedMember = 3;
                fleche.transform.position = new Vector3((float)-4.83, (float)4.15, 0);
            }
        }


    }
}
