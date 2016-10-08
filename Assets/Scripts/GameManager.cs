using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Private PlayerManager
    //Private DietyManager
    //Private TeamManager

    private static GameManager patate = null;
    private bool gameIsRunning = true;
    private int turn = 0;
    private int[] actionP1 = new int[4];
    private int[] actionP2 = new int[4];
    public bool bothPlayerReady = false;


    //Called Before start
    void Awake()
    {
        patate = this;

    }

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(GameLoop());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f") == true)
        {
            int[] x = { 1, 1, 3, 4 };
            int[] y = { 0, 2, 4, 6 };
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
    }

    private void executeAction()
    {

        debugActionTab();

    }

    IEnumerator GameLoop()
    {
        Debug.Log("STARTING GAME");
        while (gameIsRunning)
        {
            Debug.Log("Turn : " + turn);
            Debug.Log("START WAIT FOR INPUT");
            yield return new WaitUntil(() => bothPlayerReady == true);
            Debug.Log("END WAIT FOR INPUT");
            bothPlayerReady = false;
            turn++;

            executeAction();
            
        }
    }

    public void debugActionTab()
    {
        Debug.Log("ActionP1: " + actionP1[0] + actionP1[1] + actionP1[2] + actionP1[3]);
        Debug.Log("ActionP2: " + actionP2[0] + actionP2[1] + actionP2[2] + actionP2[3]);
    }

    public void FUCK()
    {
        Debug.Log("AFHAJDHS");
    }

}
