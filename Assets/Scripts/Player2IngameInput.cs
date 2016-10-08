using UnityEngine;
using System.Collections;

public class Player2IngameInput : MonoBehaviour {

    private int selectedMember = 0;
    private int[] actions = new int[4];

    public SpriteRenderer fleche;

    // Use this for initialization
    void Start () {
        foreach (int x in actions)
            actions[x] = -1;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("BoutonAP2"))
        {
            //ART
            actions[selectedMember] = 2;
        }
        if (Input.GetButtonDown("BoutonBP2"))
        {
            //PROGRAMMER
            actions[selectedMember] = 1;
        }
        if (Input.GetButtonDown("BoutonXP2"))
        {
            //HACKER
            actions[selectedMember] = 3;
        }
        if (Input.GetButtonDown("BoutonYP2"))
        {
            //DORMIR
            actions[selectedMember] = 0;
        }

        if (Input.GetButtonDown("BoutonStartP2"))
        {
            int cpt = 0;
            foreach (int x in actions)
            {
                if (x == -1)
                    break;
                if (cpt == 3)
                    GameManager.Instance.setAction(actions, 1);
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
}
