using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreFinal : MonoBehaviour {

    ScorePatate scoreP;
    public GameObject gameHallah_doors;
    public Text TP1;
    public Text TP2;
    public Text winnerText;
    public GameObject art_god_1;
    public GameObject prog_god_1;
    public GameObject salt_god_1;
    public GameObject sleep_god_1;
    public GameObject art_god_2;
    public GameObject prog_god_2;
    public GameObject salt_god_2;
    public GameObject sleep_god_2;
    public AudioSource welcome;
    public int theme;

    public float mult_P1 = 1;
    public float mult_P2 = 1;

    float totalP1;
    float totalP2;

    string[,] multThemeStyle = new string[12, 2] { { "Competition", "Manage"}, { "Action", "Survival"}, { "Turn by turn", "Strategy"}, { "Romance", "Rythm"}, { "Puzzle", "Interactive"}, { "Racing", "Exploration"}, { "Turn by turn", "Strategy"}, { "Romance", "Action"}, { "Competition", "Interactive" }, { "Survival", "Exploration"}, { "Management", "Rythm"}, { "Puzzle", "Racing"} };


    // Use this for initialization
    void Start () {
        scoreP = GameObject.FindGameObjectWithTag("Score").GetComponent<ScorePatate>();
        StartCoroutine("LaunchDoorsAnimation");
        if (scoreP.GodFavor[0] < 0.5)
        {
            prog_god_1.SetActive(false);
            prog_god_2.SetActive(true);
            scoreP.ScoreTeam2[0]*= 1.15f;
        }
        if (scoreP.GodFavor[0] > 0.5)
        {
            prog_god_1.SetActive(true);
            prog_god_2.SetActive(false);
            scoreP.ScoreTeam1[0] *= 1.15f;
        }
        if (scoreP.GodFavor[1] < 0.5)
        {
            art_god_1.SetActive(false);
            art_god_2.SetActive(true);
            scoreP.ScoreTeam2[1] *= 1.15f;
        }
        if (scoreP.GodFavor[1] > 0.5)
        {
            art_god_1.SetActive(true);
            art_god_2.SetActive(false);
            scoreP.ScoreTeam1[1] *= 1.15f;
        }
        if (scoreP.GodFavor[2] < 0.5)
        {
            sleep_god_1.SetActive(false);
            sleep_god_2.SetActive(true);
            scoreP.ScoreTeam2[2] *= 1.15f;
        }
        if (scoreP.GodFavor[2] > 0.5)
        {
            sleep_god_1.SetActive(true);
            sleep_god_2.SetActive(false);
            scoreP.ScoreTeam1[2] *= 1.15f;
        }
        if (scoreP.GodFavor[3] < 0.5)
        {
            salt_god_1.SetActive(false);
            salt_god_2.SetActive(true);
            scoreP.ScoreTeam2[3] *= 1.15f;
        }
        if (scoreP.GodFavor[3] > 0.5)
        {
            salt_god_1.SetActive(true);
            salt_god_2.SetActive(false);
            scoreP.ScoreTeam1[3] *= 1.15f;
        }
        switch(scoreP.theme) {
            case "Judgment":
                theme = 0;  
                break;
            case "Undead":
                theme = 1;
                break;
            case "Empire":
                theme = 2;
                break;
            case "Light":
                theme = 3;
                break;
            case "Deception":
                theme = 4;
                break;
            case "Super-hero":
                theme = 5;
                break;
            case "Science":
                theme = 6;
                break;
            case "Mythology":
                theme = 7;
                break;
            case "Beach party":
                theme = 8;
                break;
            case "Between us":
                theme = 9;
                break;
            case "Food":
                theme = 10;
                break;
            case "Astrology":
                theme = 11;
                break;
            default : theme = 0;
                break;
        }
        if(scoreP.style[0] == multThemeStyle[theme,0] || scoreP.style[0] == multThemeStyle[theme, 1])
            mult_P1 = 1.10f;
        if (scoreP.style[1] == multThemeStyle[theme, 0] || scoreP.style[1] == multThemeStyle[theme, 1])
            mult_P2 = 1.10f;
        Debug.Log(mult_P1);
        totalP1 = scoreP.ScoreTeam1[0] + scoreP.ScoreTeam1[1] + scoreP.ScoreTeam1[2] + scoreP.ScoreTeam1[3] * mult_P1;
        totalP2 = scoreP.ScoreTeam2[0] + scoreP.ScoreTeam2[1] + scoreP.ScoreTeam2[2] + scoreP.ScoreTeam2[3] * mult_P2;
        TP1.text = totalP1.ToString();
        TP2.text = totalP2.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator LaunchDoorsAnimation()
    {
        gameHallah_doors.GetComponent<Animator>().enabled = false;
        winnerText.text = "";

        yield return new WaitForSeconds(5);

        gameHallah_doors.GetComponent<Animator>().enabled = true;
        winnerText.text = winnerPlayer();
    }

    private string winnerPlayer()
    {
        welcome.Play();
        Debug.Log(totalP2 + "");
        if (totalP1 > totalP2)
            return "PLAYER 1 WIN";
        else if (totalP1 < totalP2)
            return "PLAYER 2 WIN";
        else
            return "TIE !";
    }
}


