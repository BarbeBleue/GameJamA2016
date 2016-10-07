using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BaseCharacter : MonoBehaviour
{
	[HideInInspector] public int m_ArtLevel;
	[HideInInspector] public int m_ProgLevel;
	[HideInInspector] public int m_SleepResist; // must be a value between 1 and 5
	[HideInInspector] public int m_AttackLevel;

	public GameObject m_Instance;

	private int m_SleepLevel;
	private int m_MaxSleep = 100;
	private int m_MinSleep = 0;

	private int m_TempArtLevel;  //Temporary values for character's stats affected by the sleepLevel of said Character
	private int m_TempProgLevel;
	private int m_TempAttackLevel;

	public void Setup()
	{
		m_SleepLevel = m_MaxSleep;
		//m_Instance.GetComponent<> ();
	}

	public void IsNotSleeping ()
	{
		m_SleepLevel -= 10 / m_SleepResist;

		if (m_SleepLevel <= 50)
			StartCoroutine (SleepyHead ());
		else if (m_SleepLevel <= 0)
			StartCoroutine (Dead ());
	}

	public int ProgAction()
	{
		m_TempProgLevel = m_ProgLevel * (m_SleepLevel/m_MaxSleep);

		return m_TempProgLevel;
	}

	public int ArtAction()
	{
		m_TempArtLevel = m_ArtLevel * (m_SleepLevel / m_MaxSleep);

		return m_TempArtLevel;
	}

	public int AttackAction()
	{
		m_TempAttackLevel = m_AttackLevel * (m_SleepLevel / m_MaxSleep);

		return m_TempAttackLevel;
	}

	IEnumerator SleepyHead()
	{
		//I'm feeling sleepy
		yield return null;
	}

	IEnumerator Dead()
	{
		//I'm dead QQ
		yield return null;
	}
}
