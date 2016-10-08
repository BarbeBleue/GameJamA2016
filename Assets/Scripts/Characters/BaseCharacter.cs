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

	public GameObject m_SleepyHead;
	public GameObject m_Dead;
	public GameObject m_FeelingFresh;
	public GameObject m_Attacking;
	public GameObject m_Sleeping;
	public GameObject m_Programming;
	public GameObject m_Arting;

	public DeusEx m_DeusInstance;
	public GameObject m_Instance;

	private Transform m_ArtGodPosition;
	private Transform m_ProgGodPosition;
	private Transform m_SleepGodPosition;
	private Transform m_SaltGodPosition;
	private Transform m_characterPosition;
	private int m_SleepLevel;
	private int m_MaxSleep = 100;
	//private int m_MinSleep = 0;

	/*
	private float m_TempArtLevel;  //Temporary values for character's stats affected by the sleepLevel of said Character
	private int m_TempProgLevel;
	private int m_TempAttackLevel;
	*/

	private float m_ArtProduced;
	private int m_ProgProduced;
	private int m_AttackProduced;

	public void Awake()
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

	public int SleepAction()
	{
		m_SleepLevel += 50;

		if (m_SleepLevel >= 100)
		{
			m_SleepLevel = 100;
			StartCoroutine (FeelingFresh ());
		}

		StartCoroutine (Sleeping ());
        return m_SleepLevel;
	}

	public int ProgAction()
	{
        
		int m_TempProgLevel = m_ProgLevel * (m_SleepLevel/m_MaxSleep);
		m_ProgProduced = 10 * m_TempProgLevel;
        return m_ProgProduced;
	}

	public float ArtAction()
	{
		float m_TempArtLevel = m_ArtLevel * (m_SleepLevel / m_MaxSleep);
		m_ArtProduced = 0.1f * m_TempArtLevel;

		StartCoroutine (Arting ());
        return m_ArtProduced;
	}

	public int AttackAction()
	{
		int m_TempAttackLevel = m_AttackLevel * (m_SleepLevel / m_MaxSleep);
		m_AttackProduced = 10 * m_TempAttackLevel;

		StartCoroutine (Attacking ());

		return m_AttackProduced;
	}

	IEnumerator SleepyHead()
	{
		//I'm feeling sleepy
		GameObject patate = Instantiate (m_SleepyHead, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Dead()
	{
		//I'm dead QQ
		GameObject patate = Instantiate (m_Dead, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator FeelingFresh()
	{
		//Je me sens reposé!
		GameObject patate = Instantiate (m_FeelingFresh, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Sleeping()
	{
		//move character to couch
		GameObject patate = Instantiate (m_Sleeping, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Attacking()
	{
		//bubble d'attaque vers le dieu du sel
		GameObject patate = Instantiate (m_Attacking, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_AttackLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		yield return null;

		DestroyObject(patate);
	}

	IEnumerator Programming()
	{
		//bubble de prog vers le dieu de la prog
		GameObject patate = Instantiate (m_Programming, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_ProgLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		yield return null;

		DestroyObject(patate);
	}

	IEnumerator Arting ()
	{
		//bubble de art vers le dieu Pierre
		GameObject patate = Instantiate (m_Arting, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_ArtLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		yield return null;

		DestroyObject(patate);
	}

}
