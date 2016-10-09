using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreFinal : MonoBehaviour {

    ScorePatate scoreP;
    public Text Prog_1;
    public Text Art_1;
    public Text Salt_1;
    public Text Sleep_1;
    public Text Prog_2;
    public Text Art_2;
    public Text Salt_2;
    public Text Sleep_2;
    public Text M_P1;
    public Text M_P2;
    public Text TP1;
    public Text TP2;
    public GameObject art_god_1;
    public GameObject prog_god_1;
    public GameObject salt_god_1;
    public GameObject sleep_god_1;
    public GameObject art_god_2;
    public GameObject prog_god_2;
    public GameObject salt_god_2;
    public GameObject sleep_god_2;
    public int theme;

    public float mult_P1 = 1;
    public float mult_P2 = 1;

    float totalP1;
    float totalP2;

    string[,] multThemeStyle = new string[12, 2] { { "Competitif", "Gestion"}, { "Action", "Survie"}, { "Tour par tour", "Strategie"}, { "Romance", "Rythme"}, { "Puzzle", "Interactif"}, { "Course", "Exploration"}, { "Tour par tour", "Strategie"}, { "Romance", "Action"}, { "Competitif", "Interactif" }, { "Survie", "Exploration"}, { "Gestion", "Rythme"}, { "Puzzle", "Course"} };


    // Use this for initialization
    void Start () {
        scoreP = GameObject.FindGameObjectWithTag("Score").GetComponent<ScorePatate>();
        if (scoreP.GodFavor[0] > 0.5)
        {
            prog_god_1.SetActive(false);
            prog_god_2.SetActive(true);
            scoreP.ScoreTeam2[0]*= 1.15f;
        }
        if (scoreP.GodFavor[0] < 0.5)
        {
            prog_god_1.SetActive(true);
            prog_god_2.SetActive(false);
            scoreP.ScoreTeam1[0] *= 1.15f;
        }
        if (scoreP.GodFavor[1] > 0.5)
        {
            art_god_1.SetActive(false);
            art_god_2.SetActive(true);
            scoreP.ScoreTeam2[1] *= 1.15f;
        }
        if (scoreP.GodFavor[1] < 0.5)
        {
            art_god_1.SetActive(true);
            art_god_2.SetActive(false);
            scoreP.ScoreTeam1[1] *= 1.15f;
        }
        if (scoreP.GodFavor[2] > 0.5)
        {
            sleep_god_1.SetActive(false);
            sleep_god_2.SetActive(true);
            scoreP.ScoreTeam2[2] *= 1.15f;
        }
        if (scoreP.GodFavor[2] < 0.5)
        {
            sleep_god_1.SetActive(true);
            sleep_god_2.SetActive(false);
            scoreP.ScoreTeam1[2] *= 1.15f;
        }
        if (scoreP.GodFavor[3] > 0.5)
        {
            salt_god_1.SetActive(false);
            salt_god_2.SetActive(true);
            scoreP.ScoreTeam2[3] *= 1.15f;
        }
        if (scoreP.GodFavor[3] < 0.5)
        {
            salt_god_1.SetActive(true);
            salt_god_2.SetActive(false);
            scoreP.ScoreTeam1[3] *= 1.15f;
        }
        Prog_1.text = scoreP.ScoreTeam1[0].ToString();
        Art_1.text = scoreP.ScoreTeam1[1].ToString();
        Sleep_1.text = scoreP.ScoreTeam1[2].ToString();
        Salt_1.text = scoreP.ScoreTeam1[3].ToString();
        Prog_2.text = scoreP.ScoreTeam2[0].ToString();
        Art_2.text = scoreP.ScoreTeam2[1].ToString();
        Sleep_2.text = scoreP.ScoreTeam2[2].ToString();
        Salt_2.text = scoreP.ScoreTeam2[3].ToString();
        switch(scoreP.theme) {
            case "Jugement":
                theme = 0;  
                break;
            case "Mort-vivant":
                theme = 1;
                break;
            case "Empire":
                theme = 2;
                break;
            case "Lumiere":
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
            case "Olympe":
                theme = 7;
                break;
            case "Beach party":
                theme = 8;
                break;
            case "Enre nous":
                theme = 9;
                break;
            case "Nourriture":
                theme = 10;
                break;
            case "Astrologie":
                theme = 11;
                break;
            default : theme = 0;
                break;
        }
        if(scoreP.style[0] == multThemeStyle[theme,0] || scoreP.style[0] == multThemeStyle[theme, 1])
            mult_P1 = 1.10f;
        if (scoreP.style[1] == multThemeStyle[theme, 0] || scoreP.style[0] == multThemeStyle[theme, 1])
            mult_P2 = 1.10f;
        Debug.Log(mult_P1);
        M_P1.text = mult_P1.ToString();
        M_P2.text = mult_P2.ToString();
        totalP1 = scoreP.ScoreTeam1[0] + scoreP.ScoreTeam1[1] + scoreP.ScoreTeam1[2] + scoreP.ScoreTeam1[3] * mult_P1;
        totalP2 = scoreP.ScoreTeam2[0] + scoreP.ScoreTeam2[1] + scoreP.ScoreTeam2[2] + scoreP.ScoreTeam2[3] * mult_P2;
        TP1.text = totalP1.ToString();
        TP2.text = totalP2.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
