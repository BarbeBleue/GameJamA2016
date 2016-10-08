using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Slider m_Slider;
    private static Timer timer;
	void Awake()
    {
        timer = this;
    }

    public static Timer Instance
    {
        get
        {
            return timer;
        }
    }
	 public void Ready () {
        m_Slider.value++;
	}
}
