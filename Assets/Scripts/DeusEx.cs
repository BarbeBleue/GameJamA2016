using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeusEx : MonoBehaviour {

	[HideInInspector] public float m_StartingFavor;
	[HideInInspector] public float m_CurrentFavor;

	public Slider m_Slider;
	public Image m_FillImage;
	public Color m_FullFavorColor = Color.green;
	public Color m_ZeroFavorColor = Color.red;
    public enum Diet {Salty, Prog, Art, Sleep};

	public static DeusEx instance = null;

	void Awake ()
	{		
		m_StartingFavor = m_CurrentFavor = 0.5f;
	}

	public void Player2Favor(float adder)
	{
		m_CurrentFavor -= adder;
        SetFavorUI();
    }

	public void Player1Favor(float substracter)
	{
		m_CurrentFavor += substracter;
        SetFavorUI();
    }

	public void SetFavorUI()
	{
		m_Slider.value = m_CurrentFavor;
	}
}
