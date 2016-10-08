using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public Text actionHacker;
    public Text actionProg;
    public Text actionArtiste;
    public Text actionGen;
    public Text PersonneChoisi;

    public int selectedMember = 0;
    public int[] actions = new int[4]; 

    // Use this for initialization
    void Start () {
        foreach (int x in actions)
        {
            actions[x] = -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("OptionA"))
        {
            //ART
            actions[selectedMember] = 2;
        }
        if (Input.GetButtonDown("OptionB"))
        {
            //PROGRAMMER
            actions[selectedMember] = 1;
        }
        if (Input.GetButtonDown("OptionY"))
        {
            //DORMIR
            actions[selectedMember] = 0;
        }
        if (Input.GetButtonDown("OptionX"))
        {
            //HACKER
            actions[selectedMember] = 3;
        }
        if (Input.GetAxis("XDpad") == 1)
        {
            //UP ARROW ARTISTE
            selectedMember = 0;
        }
        if (Input.GetAxis("XDpad") == -1)
        {
            //DOWN ARROW PROGRAMMEUR
            selectedMember = 2;
        }
        if (Input.GetAxis("YDpad") == 1)
        {
            //RIGHT ARROW GENERALISTE
            selectedMember = 1;
        }
        if (Input.GetAxis("YDpad") == -1)
        {
            //LEFT ARROW HACKER
            selectedMember = 3;
        }
    }
}
