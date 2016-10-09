using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

    public Camera m_MainCamera;
    public DeusExManager deusExManager;
    private Timer timer;
    public Team[] teams = new Team[2];
    private EventSystem eventSystem;
    private static GameManager patate = null;
    private bool gameIsRunning = false;
    private bool gameHasEnded = false;
    private int turn = 12;
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

    ScorePatate scoreFinal;

    private Vector3[] spawnpoints = { new Vector3(-1,10,0),
                                      new Vector3(-1,20,0),
                                      new Vector3(26,10,0),
                                      new Vector3(26,20,0)};

    public GameObject potato;
    private GameObject refato;

    public float eventChance = 0.25f;
    public float timeBetweenTurn = 2.0f;

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
        string pathThemes = "Assets/Ressources/themes.txt";
        using (StreamReader sr = File.OpenText(pathThemes))
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
            Debug.Log("All set");
            InitGame();
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
            newT = true;
            Debug.Log(GetCurrentEvent().FlavorText);
            Debug.Log("START WAIT FOR INPUT");
            yield return new WaitUntil(() => bothPlayerReady == true);
            Debug.Log("END WAIT FOR INPUT");
            bothPlayerReady = false;
            timer.Ready();
            turn++;
            GameObject checkteam1GO = GameObject.Find("checkTeam1");
            SpriteRenderer checkP1 = checkteam1GO.GetComponent<SpriteRenderer>();
            checkP1.enabled = false;

            GameObject checkteam2GO = GameObject.Find("checkTeam2");
            SpriteRenderer checkP2 = checkteam2GO.GetComponent<SpriteRenderer>();
            checkP2.enabled = false;

            playersHasAnswered[0] = false;
            playersHasAnswered[1] = false;
            playerReadiness[0] = false;
            playerReadiness[1] = false;

            executeActions();
            if (turn >= maxTurn)
                EndGame();
            yield return new WaitForSeconds(timeBetweenTurn);            
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
        scoreFinal.ScoreTeam1[0]=teams[0].ProgrammingScore;
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
        gameHasEnded = true;
        gameIsRunning = false;
        Debug.Log("FUCK DA POLICE");
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


}
