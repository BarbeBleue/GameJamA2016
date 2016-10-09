using UnityEngine;
using System.Collections;

public class DeusExManager : MonoBehaviour {

    public GameObject s_artGod;
    public GameObject s_progGod;
    public GameObject s_saltGod;
    public GameObject s_sleepGod;

    private DeusEx artGod;
    private DeusEx progGod;
    private DeusEx saltGod;
    private DeusEx sleepGod;

    // Use this for initialization
    void Start () {

        

    }

    void Awake()
    {

        artGod = s_artGod.gameObject.AddComponent<DeusEx>();
        progGod = s_progGod.gameObject.AddComponent<DeusEx>();
        saltGod = s_saltGod.gameObject.AddComponent<DeusEx>();
        sleepGod = s_sleepGod.gameObject.AddComponent<DeusEx>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public DeusEx GetAGod(int numeroDieu)
    {

        switch (numeroDieu)
        {
            case 0:
                return artGod;
            case 1:
                return progGod; ;
            case 2:
                return saltGod; ;
            case 3:
                return sleepGod; ;
            default:
                return artGod; ;
        }
    }
}
