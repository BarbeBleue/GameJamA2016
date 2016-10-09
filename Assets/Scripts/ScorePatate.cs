using UnityEngine;
using System.Collections;

public class ScorePatate : MonoBehaviour {

    public float[] ScoreTeam1 = new float[4];
    public float[] ScoreTeam2 = new float[4];
    public float[] GodFavor = new float[4];
    public string theme;
    public string[] style = new string[2];

    public static ScorePatate instance = null;
    void Awake ()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static ScorePatate Instance
    {
        get
        {
            return instance;
        }

    }
}
