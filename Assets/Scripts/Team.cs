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
