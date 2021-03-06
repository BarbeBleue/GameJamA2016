﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {
    [HideInInspector]public bool moving = false;

    public Camera m_MainCamera;
    public DeusExManager deusExManager;
    public AudioSource workHard;
    public SpriteRenderer fb;
    public SpriteRenderer fr;
    public SpriteRenderer checkB;
    public SpriteRenderer checkR;
    public GameObject NextTurnText;
    public Player1IngameInput P1IngameInputs;
    public Player2IngameInput P2IngameInputs;
    public GameObject TitleScreen;
    public GameObject tutoGod;
    public GameObject tutoChars;
    private Timer timer;
    public Team[] teams = new Team[2];
    private EventSystem eventSystem;
    private static GameManager patate = null;
    private bool gameIsRunning = false;
    private bool gameHasEnded = false;
    private int turn = 0;
    private bool[] playersHasAnswered = new bool[2];
    private int[] actionP1 = new int[4];
    private int[] actionP2 = new int[4];
    [HideInInspector] public bool[] playerReadiness = new bool[2];
    private bool[] styleSet = new bool[2];
    private bool themeSet;
    private bool bothPlayerReady = false;
	private int P1 = 1, P2 = 2;
    private string theme;
    public int maxTurn = 16;
    public bool newT;
    private Event Eve;

    ScorePatate scoreFinal;

    private Vector3[] spawnpoints = { new Vector3(-1,10,0),
                                      new Vector3(-1,20,0),
                                      new Vector3(26,10,0),
                                      new Vector3(26,20,0)};

    public GameObject potato;
    private GameObject refato;

    public float eventChance = 0.25f;
    public float timeBetweenTurn = 3.0f;

    //gets

    //Called Before start
    void Awake()
    {
        eventSystem = new EventSystem(eventChance);
        /*
            teams[0] = this.gameObject.AddComponent<Team>();
            teams[1] = this.gameObject.AddComponent<Team>();
            */
        //deusExManager = this.gameObject.GetComponent<DeusExManager>();
        patate = this;
    }

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(launchGame());
        P1IngameInputs.enabled = false;
        P2IngameInputs.enabled = false;
        //deusExManager = DeusExManager.Instance;
        scoreFinal = ScorePatate.Instance;
        themeSet = false;
        SetTheme();
        styleSet[0] = false;
        styleSet[1] = false;
        timer = Timer.Instance;
        playerReadiness[0] = false;
        playerReadiness[1] = false;
		teams[0].defineTeam(P1);
		teams[1].defineTeam(P2);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown("r") == true)
        {
            RestartGame();
        }

        if (gameIsRunning)
        {
            CheckPlayerStatus();

            if (Input.GetKeyDown("f") == true)
            {
                int[] x = { 0, 1, 2, 3 };
                int[] y = { 0, 1, 2, 3 };
                setAction(x, 0);
                setAction(y, 1);
            }
        }
        else if(!gameHasEnded)
        {
            CheckMenuStatus();
        }

        if (Input.GetKeyDown("p") == true)
        {
            LaunnchAPotato();
        }
        if (Input.GetKeyDown("s") == true)
        {
            SetTeamStyle("Scrub",0);
            SetTeamStyle("Wololol",1);
            SetTheme();
        }
    }

    private void InitGame()
    {
        GameObject.Find("Menu").SetActive(false);
        workHard.Play();
        gameIsRunning = true;
        playersHasAnswered[0] = false;
        playersHasAnswered[1] = false;
        StartGame();
    }

    public void SetTeamStyle(string _style, int teamId)
    {
        if (teamId == 0)
        {
            teams[0].setStyle(_style);
            styleSet[0] = true;
            playersHasAnswered[0] = true;
        }
        else
        {
            teams[1].setStyle(_style);
            styleSet[1] = true;
            playersHasAnswered[1] = true;
        }


    }

    public void SetTheme()
    {
        List<string> lesThemes = new List<string>();
        using (StreamReader sr = File.OpenText(Application.dataPath + "/themes.txt"))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                lesThemes.Add(s);
            }

        }

        theme = lesThemes[new System.Random().Next(0, lesThemes.Count)];

        GameObject.Find("Theme").GetComponent<Text>().text = "Theme: " + theme;

        themeSet = true;
    }

    private void LaunnchAPotato()
    {
        switch ((int)Random.Range(0, 4))
        {
            case 0:
                refato = Instantiate(potato, spawnpoints[0], Quaternion.identity) as GameObject;
                refato.GetComponent<Rigidbody2D>().velocity = new Vector2(12, 12);
                break;
            case 1:
                refato = Instantiate(potato, spawnpoints[1], Quaternion.identity) as GameObject;
                refato.GetComponent<Rigidbody2D>().velocity = new Vector2(12, 0);
                break;
            case 2:
                refato = Instantiate(potato, spawnpoints[2], Quaternion.identity) as GameObject;
                refato.GetComponent<Rigidbody2D>().velocity = new Vector2(-12, 12);
                break;
            case 3:
                refato = Instantiate(potato, spawnpoints[3], Quaternion.identity) as GameObject;
                refato.GetComponent<Rigidbody2D>().velocity = new Vector2(-12, 0);
                break;
            default:
                refato = Instantiate(potato, spawnpoints[0], Quaternion.identity) as GameObject;
                refato.GetComponent<Rigidbody2D>().velocity = new Vector2(12, 12);
                break;
        }
    }

    IEnumerator Potagnarök()
    {
        while( 1 == 1)
        {
            LaunnchAPotato();
            yield return new WaitForSeconds(0.2f);
        }

    }

    public static GameManager Instance
    {
        get
        {
            return patate;
        }

    }


    public void setAction(int[] teamAction, int teamId)
    {
        if(teamId == 0)
        {
            actionP1 = teamAction;
            playerReadiness[0] = true;
            playersHasAnswered[0] = true;
        }

        else
        {
            actionP2 = teamAction;
            playerReadiness[1] = true;
            playersHasAnswered[1] = true;
        }
            

    }


    private void CheckMenuStatus()
    {

        if (styleSet[0] == true && styleSet[1] == true && themeSet)
        {
            InitGame();
            P1IngameInputs.enabled = true;
            P2IngameInputs.enabled = true;
        }

    }

    private void CheckPlayerStatus()
    {

        if (playerReadiness[0] == true && playerReadiness[1] == true)
        {
            bothPlayerReady = true;
        }
        else
        {
            bothPlayerReady = false;
        }

    }

    private void executeActions()
    {

            teams[0].executeAction(actionP1);
            teams[1].executeAction(actionP2);

    }

    IEnumerator GameLoop()
    {
        Debug.Log("STARTING GAME");
        while (gameIsRunning)
        {
            Debug.Log("Turn : " + turn);
            eventSystem.newTurn();

            Eve = eventSystem.GetCurrentEvent();

            if (Eve.id != -1)
            {
                Debug.Log("patate");
                foreach (BaseCharacter Char in teams[0].character)
                    Char.Panic();
                foreach (BaseCharacter Char in teams[1].character)
                    Char.Panic();
            }

            newT = true;
            Debug.Log(GetCurrentEvent().FlavorText);
            Debug.Log("START WAIT FOR INPUT");
            yield return new WaitUntil(() => bothPlayerReady == true);

            Debug.Log("END WAIT FOR INPUT");
            bothPlayerReady = false;
            timer.Ready();
            turn++;
            StartCoroutine(MoveFromTo(new Vector3(1800f, 600, 0), new Vector3(-1200f, 600, 0), 3f, NextTurnText));
            checkB.enabled = false;
            checkR.enabled = false;

            playersHasAnswered[0] = false;
            playersHasAnswered[1] = false;
            playerReadiness[0] = false;
            playerReadiness[1] = false;

            executeActions();

            yield return new WaitForSeconds(timeBetweenTurn);
            if (turn >= maxTurn)
                EndGame();
            P1IngameInputs.resetActions();
            P2IngameInputs.resetActions();

            fb.enabled = true;
            fr.enabled = true;
            P1IngameInputs.enabled = true;
            P2IngameInputs.enabled = true;
        }
    }


    public void StartGame()
    {

        StartCoroutine(GameLoop());

    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void EndGame()
    {
        scoreFinal.ScoreTeam1[0] = teams[0].ProgrammingScore;
        scoreFinal.ScoreTeam1[1] = teams[0].ArtScore;
        scoreFinal.ScoreTeam1[2] = teams[0].SleepnessScore;
        scoreFinal.ScoreTeam1[3] = teams[0].SaltynessScore;
        scoreFinal.ScoreTeam2[0] = teams[1].ProgrammingScore;
        scoreFinal.ScoreTeam2[1] = teams[1].ArtScore;
        scoreFinal.ScoreTeam2[2] = teams[1].SleepnessScore;
        scoreFinal.ScoreTeam2[3] = teams[1].SaltynessScore;
        scoreFinal.GodFavor[0] = deusExManager.s_progGod.gameObject.GetComponentInChildren<DeusEx>().m_Slider.value;
        scoreFinal.GodFavor[1] = deusExManager.s_artGod.gameObject.GetComponentInChildren<DeusEx>().m_Slider.value;
        scoreFinal.GodFavor[2] = deusExManager.s_sleepGod.gameObject.GetComponentInChildren<DeusEx>().m_Slider.value;
        scoreFinal.GodFavor[3] = deusExManager.s_saltGod.gameObject.GetComponentInChildren<DeusEx>().m_Slider.value;
        scoreFinal.theme = theme;
        scoreFinal.style[0] = teams[0].style;
        scoreFinal.style[1] = teams[1].style;
        SceneManager.LoadScene("ScoreBoard");
        fb.enabled = false;
        fr.enabled = false;
        checkB.enabled = false;
        checkR.enabled = false;
        gameHasEnded = true;
        gameIsRunning = false;
        StartCoroutine(Potagnarök());

    }

    public void debugActionTab()
    {
        Debug.Log("ActionP1: " + actionP1[0] + actionP1[1] + actionP1[2] + actionP1[3]);
        Debug.Log("ActionP2: " + actionP2[0] + actionP2[1] + actionP2[2] + actionP2[3]);
    }

    public Team GetATeam(int player)
    {
        return teams[player];
    }

    public Event GetCurrentEvent()
    {

        return eventSystem.GetCurrentEvent();

    }

    public DeusExManager getDatDeuxSexManager()
    {

        return deusExManager;

    }

    public void FUCK()
    {
        Debug.Log("AFHAJDHS");
    }

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time, GameObject potato)
    {
        if (!moving)
        { // do nothing if already moving
            moving = true; // signals "I'm moving, don't bother me!"
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
                potato.transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
                yield return 0; // leave the routine and return here in the next frame
            }
            moving = false; // finished moving
        }
    }

    IEnumerator launchGame()
    {
        TitleScreen.SetActive(true);
        tutoChars.SetActive(false);
        tutoGod.SetActive(false);

        yield return new WaitForSeconds(3);

        TitleScreen.SetActive(false);
        tutoChars.SetActive(true);
        tutoGod.SetActive(false);

        yield return new WaitForSeconds(10);

        TitleScreen.SetActive(false);
        tutoChars.SetActive(false);
        tutoGod.SetActive(true);

        yield return new WaitForSeconds(6);


        TitleScreen.SetActive(false);
        tutoChars.SetActive(false);
        tutoGod.SetActive(false);

    }

}
