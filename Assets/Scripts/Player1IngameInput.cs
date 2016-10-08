using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1IngameInput : MonoBehaviour {

    private int selectedMemberP1 = 0;
    private int[] actionsP1 = new int[4];

    public SpriteRenderer fleche;

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
            if (selectedMemberP1 != 0)
            {
                selectedMemberP1 = 0;
                fleche.transform.position = new Vector3((float)-3.36, (float)5.02, 0);
            }
        }
        if (Input.GetAxis("XDpadP1") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            if (selectedMemberP1 != 2)
            {
                selectedMemberP1 = 2;
                fleche.transform.position = new Vector3((float)-3.39, (float)2.83, 0);
            }
        }
        if (Input.GetAxis("YDpadP1") == 1)
        {
            //RIGHT ARROW GENERALISTE
            if (selectedMemberP1 != 1)
            {
                selectedMemberP1 = 1;
                fleche.transform.position = new Vector3((float)-1.77, (float)4.02, 0);
            }
        }
        if (Input.GetAxis("YDpadP1") == -1)
        {
            //LEFT ARROW HACKER
            if (selectedMemberP1 != 3)
            {
                selectedMemberP1 = 3;
                fleche.transform.position = new Vector3((float)-4.89, (float)3.87, 0);
            }
        }


    }
}
