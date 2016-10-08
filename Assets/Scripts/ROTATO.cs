using UnityEngine;
using System.Collections;

public class ROTATO : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(5, -5, -5);
    }
}
