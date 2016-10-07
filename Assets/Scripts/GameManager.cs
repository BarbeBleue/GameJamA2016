using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Private PlayerManager
    //Private DietyManager
    //Private TeamManager

    private static GameManager patate = null;
    private bool gameIsRunning = true;
    private int turn = 0;
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
            bothPlayerReady = true;
    }

    public static GameManager Instance
    {
        get
        {
            return patate;
        }

    }

    IEnumerator GameLoop()
    {
        Debug.Log("STARTING GAME");
        while (gameIsRunning)
        {
            Debug.Log("START WAIT FOR INPUT");
            yield return new WaitUntil(() => bothPlayerReady == true);
            Debug.Log("END WAIT FOR INPUT");
            bothPlayerReady = false;
            turn++;
            Debug.Log("Turn : " + turn);
        }
    }

    public void FUCK()
    {
        Debug.Log("AFHAJDHS");
    }
}
