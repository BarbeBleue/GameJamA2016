using UnityEngine;
using System.Collections;

public class Player2Input : MonoBehaviour {

    private int selectedMemberP2 = 0;
    private int[] actionsP2 = new int[4];
    // Use this for initialization
    void Start () {
        foreach (int x in actionsP2)
            actionsP2[x] = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("BoutonAP2"))
        {
            //ART
            actionsP2[selectedMemberP2] = 2;
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
    }
}
