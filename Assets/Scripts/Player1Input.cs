using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Input : MonoBehaviour {

    private int selectedMemberP1 = 0;
    private int[] actionsP1 = new int[4];

    // Use this for initialization
    void Start () {
        foreach (int x in actionsP1)
            actionsP1[x] = -1;

    }
	
	// Update is called once per frame
	void Update () {
        //INPUTS PLAYER 1
        if (Input.GetButtonDown("BoutonAP1"))
        {
            //ART
            actionsP1[selectedMemberP1] = 2;
        }
        if (Input.GetButtonDown("BoutonBP1"))
        {
            //PROGRAMMER
            actionsP1[selectedMemberP1] = 1;
        }
        if (Input.GetButtonDown("BoutonXP1"))
        {
            //HACKER
            actionsP1[selectedMemberP1] = 3;
        }
        if (Input.GetButtonDown("BoutonYP1"))
        {
            //DORMIR
            actionsP1[selectedMemberP1] = 0;
        }

        if (Input.GetButtonDown("BoutonStartP1"))
        {
            int cpt = 0;
            foreach(int x in actionsP1)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                    GameManager.Instance.setAction(actionsP1, 0);
                cpt++;
            }
        }

        if (Input.GetAxis("XDpadP1") == 1)
        {
            //UP ARROW ARTISTE
            selectedMemberP1 = 0;
        }
        if (Input.GetAxis("XDpadP1") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            selectedMemberP1 = 2;
        }
        if (Input.GetAxis("YDpadP1") == 1)
        {
            //RIGHT ARROW GENERALISTE
            selectedMemberP1 = 1;
        }
        if (Input.GetAxis("YDpadP1") == -1)
        {
            //LEFT ARROW HACKER
            selectedMemberP1 = 3;
        }


    }
}
