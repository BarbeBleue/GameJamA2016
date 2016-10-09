using UnityEngine;
using System.Collections;

public class DeusExManager : MonoBehaviour {

    private DeusEx artGod;
    private DeusEx progGod;
    private DeusEx saltGod;
    private DeusEx sleepGod;

    // Use this for initialization
    void Start () {

        

    }

    void Awake()
    {

        artGod = this.gameObject.AddComponent<DeusEx>();
        progGod = this.gameObject.AddComponent<DeusEx>();
        saltGod = this.gameObject.AddComponent<DeusEx>();
        sleepGod = this.gameObject.AddComponent<DeusEx>();
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
