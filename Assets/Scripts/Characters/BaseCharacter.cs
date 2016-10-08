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
	//[HideInInspector] public bool ArtMoving = false;
	//[HideInInspector] public bool ProgMoving = false;
	//[HideInInspector] public bool AttackMoving = false;
	[HideInInspector] public bool moving = false;

	public GameObject m_SleepyHead;
	public GameObject m_Dead;
	public GameObject m_FeelingFresh;
	public GameObject m_Attacking;
	public GameObject m_Sleeping;
	public GameObject m_Programming;
	public GameObject m_Arting;

	public Transform m_characterPosition;

	public DeusEx m_ArtGod;
	public DeusEx m_ProgGod;
	public DeusEx m_SleepGod;
	public DeusEx m_SaltGod;
	public GameObject m_AwakeInstance;
	public GameObject m_SleepingInstance;

	private int m_SleepLevel;
	private int m_MaxSleep = 100;

	private float m_ArtProduced;
	private int m_ProgProduced;
	private int m_AttackProduced;

	public void Awake()
	{
		m_SleepLevel = m_MaxSleep;
		//m_Instance.GetComponent<> ();

		m_characterPosition = this.transform;
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

	public int ProgAction(bool player)
	{
        
		int m_TempProgLevel = m_ProgLevel * (m_SleepLevel/m_MaxSleep);
		m_ProgProduced = 10 * m_TempProgLevel;

		StartCoroutine (Programming (player));

        return m_ProgProduced;

	}

	public float ArtAction(bool player)
	{
		float m_TempArtLevel = m_ArtLevel * (m_SleepLevel / m_MaxSleep);
		m_ArtProduced = 0.1f * m_TempArtLevel;

		StartCoroutine (Arting (player));

        return m_ArtProduced;
	}

	public int AttackAction(bool player)
	{
		int m_TempAttackLevel = m_AttackLevel * (m_SleepLevel / m_MaxSleep);
		m_AttackProduced = 10 * m_TempAttackLevel;

		StartCoroutine (Attacking (player));

		return m_AttackProduced;
	}

	IEnumerator SleepyHead()
	{
		GameObject patate = Instantiate (m_SleepyHead, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Dead()
	{
		GameObject patate = Instantiate (m_Dead, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator FeelingFresh()
	{
		GameObject patate = Instantiate (m_FeelingFresh, m_characterPosition.position, m_characterPosition.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Sleeping()
	{
		GameObject patate = Instantiate (m_Sleeping, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Attacking(bool player)
	{
		GameObject patate = Instantiate (m_Attacking, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_AttackLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		Vector3 godPosition = m_SaltGod.transform.position;

		StartCoroutine (MoveFromTo (m_characterPosition.position, godPosition, 2.0f, patate));

		yield return null;
	}

	IEnumerator Programming(bool player)
	{
		GameObject patate = Instantiate (m_Programming, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_ProgLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		Vector3 godPosition = m_ProgGod.transform.position;

		StartCoroutine (MoveFromTo (m_characterPosition.position, godPosition, 2.0f, patate));

		yield return null;
	}

	IEnumerator Arting (bool player)
	{
		GameObject patate = Instantiate (m_Arting, m_characterPosition.position, m_characterPosition.rotation) as GameObject;
		float statImportance = m_ArtLevel / 10f;
		patate.transform.localScale = new Vector3 (1f * statImportance, 1f * statImportance, 0);

		Vector3 godPosition = m_ArtGod.transform.position;

		StartCoroutine (MoveFromTo (m_characterPosition.position, godPosition, 2.0f, patate));

		yield return null;
	}

	IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time, GameObject potato){
		if (!moving){ // do nothing if already moving
			moving = true; // signals "I'm moving, don't bother me!"
			float t = 0f;
			while (t < 1f){
				t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
				potato.transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
				yield return 0; // leave the routine and return here in the next frame
			}
			moving = false; // finished moving

			DestroyObject(potato);
		}
	}
}
