using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour {

    //private character characters[4];
    private float ProgrammingScore = 0;
    private float ArtScore = 0;
    private float SaltynessScore = 0;
    private float SleepnessScore = 0;

    // gets
    public float GetProgScore()
    {
        return ProgrammingScore;
    }
    public float GetArtScore()
    {
        return ArtScore;
    }
    public float GetSaltScore()
    {
        return SaltynessScore;
    }
    public float GetSleepScore()
    {
        return SleepnessScore;
    }

    // Use this for initialization
    void Start ()
    {

        
	}
	
	// Update is called once per frame
	void Update ()
    {



    }

    public void executeAction(int[] actions)
    {

        foreach (int x in actions)
        {
            switch (x)
            {
                case 0:
                    incrementProg();
                    break;
                case 1:
                    incrementArt();
                    break;
                case 2:
                    incrementSalt();
                    break;
                case 3:
                    incrementSleep();
                    break;
                default:
                    break;
            }
        }

    }

    private void incrementProg()
    {

        ProgrammingScore++;

    }

    private void incrementArt()
    {

        ArtScore++;

    }

    private void incrementSalt()
    {

        SaltynessScore++;

    }

    private void incrementSleep()
    {

        SleepnessScore++;

    }



}
