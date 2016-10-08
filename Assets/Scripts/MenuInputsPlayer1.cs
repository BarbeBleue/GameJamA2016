﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class MenuInputsPlayer1 : MonoBehaviour {
    string pathThemes;
    string pathStyles;

    List<string> lesThemes = new List<string>();
    List<string> lesStyles = new List<string>();

    public Text leTheme;

    public Text textStyle1P1;
    public Text textStyle2P1;
    public Text textStyle3P1;

    
    private string choix1P1;
    private string choix2P1;
    private string choix3P1;

    private int pageSelectionnee = 1;

    // Use this for initialization
    void Start () {
        pathThemes = "Assets/Ressources/themes.txt";
        pathStyles = "Assets/Ressources/styles.txt";

        using (StreamReader sr = File.OpenText(pathThemes))
        {
            string s = "";
            while((s=sr.ReadLine()) != null)
            {
                lesThemes.Add(s);
            }

        }

        using (StreamReader sr = File.OpenText(pathStyles))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                lesStyles.Add(s);
            }

        }
        //Choix du Player 1 (Page 1)
        choix1P1 = lesStyles[0];
        choix2P1 = lesStyles[1];
        choix3P1 = lesStyles[2];

        leTheme.text = "Theme: " + lesThemes[new System.Random().Next(0,lesThemes.Count)];

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("XDpadP1") == 1)
        {
            //UP ARROW
            if (pageSelectionnee != 1)
            {
                pageSelectionnee = 1;
                //Choix du Player 1 (Page 1)
                choix1P1 = lesStyles[0];
                choix2P1 = lesStyles[1];
                choix3P1 = lesStyles[2];
            }
        }
        if (Input.GetAxis("XDpadP1") == -1)
        {
            //DOWN ARROW
            if (pageSelectionnee != 3)
            {
                pageSelectionnee = 3;
                //Choix du Player 1 (Page 3)
                choix1P1 = lesStyles[6];
                choix2P1 = lesStyles[7];
                choix3P1 = lesStyles[8];
            }
        }
        if (Input.GetAxis("YDpadP1") == 1)
        {
            //RIGHT ARROW
            if (pageSelectionnee != 2)
            {
                pageSelectionnee = 2;
                //Choix du Player 1 (Page 2)
                choix1P1 = lesStyles[3];
                choix2P1 = lesStyles[4];
                choix3P1 = lesStyles[5];
            }
        }
        if (Input.GetAxis("YDpadP1") == -1)
        {
            //LEFT ARROW
            if (pageSelectionnee != 4)
            {
                pageSelectionnee = 4;
                //Choix du Player 1 (Page 4)
                choix1P1 = lesStyles[9];
                choix2P1 = lesStyles[10];
                choix3P1 = lesStyles[11];
            }
        }
        

        if(textStyle1P1.text != choix1P1)
            textStyle1P1.text = choix1P1;
        if (textStyle2P1.text != choix2P1)
            textStyle2P1.text = choix2P1;
        if (textStyle3P1.text != choix3P1)
            textStyle3P1.text = choix3P1;

    }


}