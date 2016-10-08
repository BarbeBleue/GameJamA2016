using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrankShittyTestScript : MonoBehaviour {

    public int teamnumber;
    public Text prog;
    public Text art;
    public Text salt;
    public Text sleep;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        prog.text = GameManager.Instance.GetATeam(teamnumber).GetProgScore().ToString();
        art.text = GameManager.Instance.GetATeam(teamnumber).GetArtScore().ToString();
        salt.text = GameManager.Instance.GetATeam(teamnumber).GetSaltScore().ToString();
        sleep.text = GameManager.Instance.GetATeam(teamnumber).GetSleepScore().ToString();
    }
}
