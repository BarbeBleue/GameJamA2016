using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Slider m_Slider;
	
	 public void Ready () {
        m_Slider.value++;
	}
}
