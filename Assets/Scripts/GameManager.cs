using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {



    //Private DietyManager

    private Team[] teams = new Team[2];
    private EventSystem eventSystem;
    private static GameManager patate = null;
    private bool gameIsRunning = true;
    private int turn = 0;
    private int[] actionP1 = new int[4];
    private int[] actionP2 = new int[4];
    private bool bothPlayerReady = false;
	private int P1 = 1, P2 = 2;


    public float eventChance = 0.25f;

    //gets

    //Called Before start
    void Awake()
    {
        eventSystem = new EventSystem(eventChance);
        teams[0] = this.gameObject.AddComponent<Team>();
        teams[1] = this.gameObject.AddComponent<Team>();
        patate = this;
    }

	// Use this for initialization
	void Start ()
    {
		teams[0].defineTeam(P1);
		teams[1].defineTeam(P2);
        StartCoroutine(GameLoop());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("f") == true)
        {
            int[] x = { 0, 1, 2, 3 };
            int[] y = { 0, 1, 2, 3 };
            setAction(x,y);
        }     
    }

    public static GameManager Instance
    {
        get
        {
            return patate;
        }

    }

    public void setAction(int[] team1, int[] team2)
    {
        actionP1 = team1;
        actionP2 = team2;
        bothPlayerReady = true;
        Debug.Log("Both teams are ready!");
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
            Debug.Log(GetCurrentEvent().FlavorText);
            //Debug.Log("START WAIT FOR INPUT");
            yield return new WaitUntil(() => bothPlayerReady == true);
            //Debug.Log("END WAIT FOR INPUT");
            bothPlayerReady = false;
            turn++;

            executeActions();
            
        }
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

    public void FUCK()
    {
        Debug.Log("AFHAJDHS");
    }

}
