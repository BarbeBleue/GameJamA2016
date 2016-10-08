using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayersInput : MonoBehaviour {

    private int selectedMemberP1 = 0;
    private int selectedMemberP2 = 0;
    private int[] actionsP1 = new int[4];
    private int[] actionsP2 = new int[4];
    private bool P1Ready = false;
    private bool P2Ready = false;
    private string membreP1 = "";
    private string membreP2 = "";

    // Use this for initialization
    void Start () {
        foreach (int x in actionsP1)
        {
            actionsP1[x] = -1;
        }
        foreach (int x in actionsP2)
        {
            actionsP2[x] = -1;
        }
    }
	
	// Update is called once per frame
	void Update () {

        switch(selectedMemberP1)
        {
            case 0:
                membreP1 = "Artiste";
                break;
            case 1:
                membreP1 = "Généraliste";
                break;
            case 2:
                membreP1 = "Programmeur";
                break;
            case 3:
                membreP1 = "Hacker";
                break;
            default:
                membreP1 = "Aucun";
                break;
        }

        switch (selectedMemberP2)
        {
            case 0:
                membreP2 = "Artiste";
                break;
            case 1:
                membreP2 = "Généraliste";
                break;
            case 2:
                membreP2 = "Programmeur";
                break;
            case 3:
                membreP2 = "Hacker";
                break;
            default:
                membreP2 = "Aucun";
                break;
        }

        //INPUTS PLAYER 1
        if (Input.GetButtonDown("BoutonAP1"))
        {
            //ART
            actionsP1[selectedMemberP1] = 2;
            Debug.Log("Player 1: " + membreP1 + ": Art");
        }
        if (Input.GetButtonDown("BoutonBP1"))
        {
            //PROGRAMMER
            actionsP1[selectedMemberP1] = 1;
            Debug.Log("Player 1: " + membreP1 + ": Programmeur");
        }
        if (Input.GetButtonDown("BoutonXP1"))
        {
            //HACKER
            actionsP1[selectedMemberP1] = 3;
            Debug.Log("Player 1: " + membreP1 + ": Hacker");
        }
        if (Input.GetButtonDown("BoutonYP1"))
        {
            //DORMIR
            actionsP1[selectedMemberP1] = 0;
            Debug.Log("Player 1: " + membreP1 + ": Dormir");
        }

        if (Input.GetButtonDown("BoutonStartP1"))
        {
            int cpt = 0;
            foreach(int x in actionsP1)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                    P1Ready = true;
                cpt++;
            }
        }

        if (Input.GetAxis("XDpadP1") == 1)
        {
            //UP ARROW ARTISTE
            selectedMemberP1 = 0;
            Debug.Log("Player 1: Artiste sélectionné");
        }
        if (Input.GetAxis("XDpadP1") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            selectedMemberP1 = 2;
            Debug.Log("Player 1: Programmeur sélectionné");
        }
        if (Input.GetAxis("YDpadP1") == 1)
        {
            //RIGHT ARROW GENERALISTE
            selectedMemberP1 = 1;
            Debug.Log("Player 1: Généraliste sélectionné");
        }
        if (Input.GetAxis("YDpadP1") == -1)
        {
            //LEFT ARROW HACKER
            selectedMemberP1 = 3;
            Debug.Log("Player 1: Hacker sélectionné");
        }

        //********************************************************************************************************************************************//

        //INPUTS PLAYER 2
        if (Input.GetButtonDown("BoutonAP2"))
        {
            //ART
            actionsP2[selectedMemberP2] = 2;
            Debug.Log("Player 2: A");
        }
        if (Input.GetButtonDown("BoutonBP2"))
        {
            //PROGRAMMER
            actionsP2[selectedMemberP2] = 1;
        }
        if (Input.GetButtonDown("BoutonXP2"))
        {
            //HACKER
            actionsP2[selectedMemberP2] = 3;
        }
        if (Input.GetButtonDown("BoutonYP2"))
        {
            //DORMIR
            actionsP2[selectedMemberP2] = 0;
        }

        if (Input.GetButtonDown("BoutonStartP2"))
        {
            int cpt = 0;
            foreach (int x in actionsP2)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                    P2Ready = true;
                cpt++;
            }
        }

        if (Input.GetAxis("XDpadP2") == 1)
        {
            //UP ARROW ARTISTE
            selectedMemberP2 = 0;
        }
        if (Input.GetAxis("XDpadP2") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            selectedMemberP2 = 2;
        }
        if (Input.GetAxis("YDpadP2") == 1)
        {
            //RIGHT ARROW GENERALISTE
            selectedMemberP2 = 1;
        }
        if (Input.GetAxis("YDpadP2") == -1)
        {
            //LEFT ARROW HACKER
            selectedMemberP2 = 3;
        }

        //********************************************************************************************************************************************//

        if (P1Ready && P2Ready)
        {
            GameManager.Instance.setAction(actionsP1, actionsP2);
            P1Ready = false;
            P2Ready = false;
        }

    }
}
