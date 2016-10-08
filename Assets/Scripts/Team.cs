using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour {

    //private character characters[4];
    private float ProgrammingScore = 0;
    private float ArtScore = 0;
    private float SaltynessScore = 0;
    private float SleepnessScore = 0;
    private BaseCharacter[] character = new BaseCharacter[4]; 

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
        character[0] =  this.gameObject.AddComponent<ArtCharacter>();
        character[1] = this.gameObject.AddComponent<NADCharacter>();
        character[2] = this.gameObject.AddComponent<ProgCharacter>();
        character[3] = this.gameObject.AddComponent<HackerCharacter>();
    }
	
	// Update is called once per frame
	void Update ()
    {



    }

    public void executeAction(int[] actions)
    {
        int index = 0;
        foreach (int x in actions)
        {
            switch (x)
            {
                case 0:
                    incrementProg(index);
                    break;
                case 1:
                    incrementArt(index);
                    break;
                case 2:
                    incrementSalt(index);
                    break;
                case 3:
                    incrementSleep(index);
                    break;
                default:
                    break;
            }
            index++;
        }

    }

    private void incrementProg(int x)
    {

        ProgrammingScore += character[x].ProgAction();
        //ProgrammingScore++;

    }

    private void incrementArt(int x)
    {

        ArtScore += character[x].ArtAction();
        //ArtScore++;

    }

    private void incrementSalt(int x)
    {

        SaltynessScore += character[x].AttackAction();
        //SaltynessScore++;

    }

    private void incrementSleep(int x)
    {
        SleepnessScore += character[x].SleepAction();
        //SleepnessScore++;

    }



}
