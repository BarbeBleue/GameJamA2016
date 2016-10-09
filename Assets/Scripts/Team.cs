using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour {

    //private character characters[4];
    public float ProgrammingScore = 0;
    public float ArtScore = 0;
    public float SaltynessScore = 0;
    public float SleepnessScore = 0;
    public float[] eventEffect = new float[4];
    public BaseCharacter[] character = new BaseCharacter[4];
	public bool playerId;
    private string style;

    SpriteRenderer Hacker1 = GameObject.Find("Hacker1").GetComponent<SpriteRenderer>();
    SpriteRenderer Hacker2 = GameObject.Find("Hacker2").GetComponent<SpriteRenderer>();

    SpriteRenderer Generalist1 = GameObject.Find("Generalist1").GetComponent<SpriteRenderer>();
    SpriteRenderer Generalist2 = GameObject.Find("Generalist2").GetComponent<SpriteRenderer>();

    SpriteRenderer Artist1 = GameObject.Find("Artist1").GetComponent<SpriteRenderer>();
    SpriteRenderer Artist2 = GameObject.Find("Artist2").GetComponent<SpriteRenderer>();

    SpriteRenderer Programmer1 = GameObject.Find("Programmer1").GetComponent<SpriteRenderer>();
    SpriteRenderer Programmer2 = GameObject.Find("Programmer2").GetComponent<SpriteRenderer>();


    SpriteRenderer Hacker_sleepin1 = GameObject.Find("Hacker_sleepin1").GetComponent<SpriteRenderer>();
    SpriteRenderer Hacker_sleepin2 = GameObject.Find("Hacker_sleepin2").GetComponent<SpriteRenderer>();

    SpriteRenderer Generalist_sleepin1 = GameObject.Find("Generalist_sleepin1").GetComponent<SpriteRenderer>();
    SpriteRenderer Generalist_sleepin2 = GameObject.Find("Generalist_sleepin2").GetComponent<SpriteRenderer>();

    SpriteRenderer Artist_sleepin1 = GameObject.Find("Artist_sleepin1").GetComponent<SpriteRenderer>();
    SpriteRenderer Artist_sleepin2 = GameObject.Find("Artist_sleepin2").GetComponent<SpriteRenderer>();

    SpriteRenderer Programmer_sleepin1 = GameObject.Find("Programmer_sleepin1").GetComponent<SpriteRenderer>();
    SpriteRenderer Programmer_sleepin2 = GameObject.Find("Programmer_sleepin2").GetComponent<SpriteRenderer>();



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
        if(character[0] == null)
            character[0] = this.gameObject.AddComponent<ArtCharacter>();
        //character [0].PutInScene (playerId);
        if (character[1] == null)
            character[1] = this.gameObject.AddComponent<NADCharacter>();
        //character [1].PutInScene (playerId);
        if (character[2] == null)
            character[2] = this.gameObject.AddComponent<ProgCharacter>();
        //character [2].PutInScene (playerId);
        if (character[3] == null)
            character[3] = this.gameObject.AddComponent<HackerCharacter>();
		//character [3].PutInScene (playerId);

        //SetEventValues();
    }

	public void defineTeam (int player)
	{
		if (player == 1)
			playerId = false;
		else
			playerId = true;			
	}
	
	// Update is called once per frame
	void Update ()
    {



    }

    public void executeAction(int[] actions)
    {
        SetEventValues();
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
                    setSleeper(index);
                    break;
                default:
                    break;
            }
            index++;
        }

    }

    private void incrementProg(int x)
    {

		ProgrammingScore += character[x].ProgAction(playerId)*eventEffect[0];
        //ProgrammingScore++;

    }

    private void incrementArt(int x)
    {

		ArtScore += character[x].ArtAction(playerId) * eventEffect[1];
        //ArtScore++;

    }

    private void incrementSalt(int x)
    {

		SaltynessScore += character[x].AttackAction(playerId) * eventEffect[2];
        //SaltynessScore++;

    }

    private void incrementSleep(int x)
    {
        SleepnessScore += character[x].SleepAction(playerId) * eventEffect[3];
        //SleepnessScore++;


    }

    private void setSleeper(int x)
    {

        if (playerId)
        {
            switch (x)
            {
                case 0:
                    Artist1.enabled = false;
                    Artist_sleepin1.enabled = true;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (x)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
    private void SetEventValues()
    {

        eventEffect[0] = GameManager.Instance.GetCurrentEvent().teamProgEffect;
        eventEffect[1] = GameManager.Instance.GetCurrentEvent().teamArtEffect;
        eventEffect[2] = GameManager.Instance.GetCurrentEvent().teamSaltEffect;
        eventEffect[3] = GameManager.Instance.GetCurrentEvent().teamSleepEffect;

    }

    public void setStyle(string _style)
    {
        style = _style;
    }

}
