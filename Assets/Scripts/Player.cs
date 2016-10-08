using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public int selectedMemberP1 = 0;
    public int selectedMemberP2 = 0;
    public int[] actionsP1 = new int[4];
    public int[] actionsP2 = new int[4];

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


        //*************************************************************************//
        //INPUTS PLAYER 2
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

        Debug.Log(selectedMemberP1);
        Debug.Log(selectedMemberP2);
    }
}
