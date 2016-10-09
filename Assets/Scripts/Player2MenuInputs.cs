using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Player2MenuInputs : MonoBehaviour {

    string pathStyles;

    List<string> lesStyles = new List<string>();

    public Text textStyle1P2;
    public Text textStyle2P2;
    public Text textStyle3P2;

    public Image Player2Fond;

    private string choix1P2;
    private string choix2P2;
    private string choix3P2;

    private int pageSelectionnee = 1;

    private string styleChoisi = "";

    // Use this for initialization
    void Start () {
        pathStyles = "Assets/Ressources/styles.txt";
        using (StreamReader sr = File.OpenText(pathStyles))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                lesStyles.Add(s);
            }

        }
        //Choix du Player 2 (Page 1)
        choix1P2 = lesStyles[0];
        choix2P2 = lesStyles[1];
        choix3P2 = lesStyles[2];
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("BoutonAP2"))
        {
            if (styleChoisi != "")
            {
                Player2Fond.color = Color.green;
                GameManager.Instance.SetTeamStyle(styleChoisi, 1);
            }
        }

        if (Input.GetButtonDown("BoutonBP2"))
        {
            styleChoisi = choix3P2;
            textStyle3P2.color = Color.white;
            textStyle1P2.color = Color.black;
            textStyle2P2.color = Color.black;
        }
        if (Input.GetButtonDown("BoutonXP2"))
        {
            styleChoisi = choix2P2;
            textStyle1P2.color = Color.black;
            textStyle2P2.color = Color.white;
            textStyle3P2.color = Color.black;
        }
        if (Input.GetButtonDown("BoutonYP2"))
        {
            styleChoisi = choix1P2;
            textStyle1P2.color = Color.white;
            textStyle3P2.color = Color.black;
            textStyle2P2.color = Color.black;
        }

        if (Input.GetAxis("XDpadP2") == 1)
        {
            //UP ARROW
            if (pageSelectionnee != 1)
            {
                pageSelectionnee = 1;
                //Choix du Player 2 (Page 1)
                choix1P2 = lesStyles[0];
                choix2P2 = lesStyles[1];
                choix3P2 = lesStyles[2];

                styleChoisi = "";
                textStyle1P2.color = Color.black;
                textStyle2P2.color = Color.black;
                textStyle3P2.color = Color.black;
            }
        }
        if (Input.GetAxis("XDpadP2") == -1)
        {
            //DOWN ARROW
            if (pageSelectionnee != 3)
            {
                pageSelectionnee = 3;
                //Choix du Player 2 (Page 3)
                choix1P2 = lesStyles[6];
                choix2P2 = lesStyles[7];
                choix3P2 = lesStyles[8];

                styleChoisi = "";
                textStyle1P2.color = Color.black;
                textStyle2P2.color = Color.black;
                textStyle3P2.color = Color.black;
            }
        }
        if (Input.GetAxis("YDpadP2") == 1)
        {
            //RIGHT ARROW
            if (pageSelectionnee != 2)
            {
                pageSelectionnee = 2;
                //Choix du Player 2 (Page 2)
                choix1P2 = lesStyles[3];
                choix2P2 = lesStyles[4];
                choix3P2 = lesStyles[5];

                styleChoisi = "";
                textStyle1P2.color = Color.black;
                textStyle2P2.color = Color.black;
                textStyle3P2.color = Color.black;
            }
        }
        if (Input.GetAxis("YDpadP2") == -1)
        {
            //LEFT ARROW
            if (pageSelectionnee != 4)
            {
                pageSelectionnee = 4;
                //Choix du Player 2 (Page 4)
                choix1P2 = lesStyles[9];
                choix2P2 = lesStyles[10];
                choix3P2 = lesStyles[11];

                styleChoisi = "";
                textStyle1P2.color = Color.black;
                textStyle2P2.color = Color.black;
                textStyle3P2.color = Color.black;
            }
        }

        if (textStyle1P2.text != choix1P2)
            textStyle1P2.text = choix1P2;
        if (textStyle2P2.text != choix2P2)
            textStyle2P2.text = choix2P2;
        if (textStyle3P2.text != choix3P2)
            textStyle3P2.text = choix3P2;
    }
}
