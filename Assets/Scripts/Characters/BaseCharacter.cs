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

    public AudioSource snoring;

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

    public float m_GodFavor = 0.125f;

	private Vector3 translate = new Vector3 (0f, 1f, 0f);

	void Awake()
	{
		m_SleepLevel = m_MaxSleep;
        //m_Instance.GetComponent<>();
        m_AwakeInstance.GetComponent<Animator>().enabled = false;

    }

    virtual public void Init()
    {
        
    }

    virtual public void Panic()
    {

    }

    IEnumerator ResetAnimator()
    {

        yield return new WaitForSeconds(GameManager.Instance.timeBetweenTurn);
        m_AwakeInstance.GetComponent<Animator>().enabled = false;

    }

    void Start()
    {
        m_ArtGod = GameManager.Instance.getDatDeuxSexManager().GetAGod(0);
        m_ProgGod = GameManager.Instance.getDatDeuxSexManager().GetAGod(1);
        m_SaltGod = GameManager.Instance.getDatDeuxSexManager().GetAGod(2);
        m_SleepGod = GameManager.Instance.getDatDeuxSexManager().GetAGod(3);

        Init();
    }

	public void IsNotSleeping ()
	{
		m_SleepLevel -= 25 / m_SleepResist;

		if (m_SleepLevel <= 50 && m_SleepLevel > 25)
			StartCoroutine (SleepyHead ());
		else if (m_SleepLevel <= 0 && m_SleepLevel <= 25)
			StartCoroutine (Dead ());
	}

	public int SleepAction(bool player)
	{
		m_SleepLevel += 50;

        StartCoroutine(Sleeping(player));

        return m_SleepLevel;
	}

	public int ProgAction(bool player)
	{
        
		int m_TempProgLevel = m_ProgLevel * (m_SleepLevel/m_MaxSleep);
		m_ProgProduced = 10 * m_TempProgLevel;
        m_AwakeInstance.GetComponent<Animator>().enabled = true;
        StartCoroutine(ResetAnimator());
        StartCoroutine (Programming (player));

        IsNotSleeping();

        return m_ProgProduced;

	}

	public float ArtAction(bool player)
	{
		float m_TempArtLevel = m_ArtLevel * (m_SleepLevel / m_MaxSleep);
		m_ArtProduced = 10 * m_TempArtLevel;
        m_AwakeInstance.GetComponent<Animator>().enabled = true;
        StartCoroutine(ResetAnimator());
        StartCoroutine (Arting (player));

        IsNotSleeping();

        return m_ArtProduced;
	}

	public int AttackAction(bool player)
	{
		int m_TempAttackLevel = m_AttackLevel * (m_SleepLevel / m_MaxSleep);
		m_AttackProduced = 10 * m_TempAttackLevel;
        m_AwakeInstance.GetComponent<Animator>().enabled = true;
        StartCoroutine(ResetAnimator());
        StartCoroutine (Attacking (player));

        IsNotSleeping();

        return m_AttackProduced;
	}

	IEnumerator SleepyHead()
	{
		GameObject patate = Instantiate (m_SleepyHead, m_AwakeInstance.transform.position + translate, m_AwakeInstance.transform.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator Dead()
	{
		GameObject patate = Instantiate (m_Dead, m_AwakeInstance.transform.position + translate, m_AwakeInstance.transform.rotation) as GameObject;

		yield return new WaitForSeconds(5);

		DestroyObject(patate);
	}

	IEnumerator FeelingFresh()
	{
		GameObject patate = Instantiate (m_FeelingFresh, m_AwakeInstance.transform.position + translate, m_AwakeInstance.transform.rotation) as GameObject;

		yield return null;

		DestroyObject (patate, 2f);
	}

	IEnumerator Sleeping(bool player)
	{
		GameObject patate = Instantiate (m_Sleeping, m_AwakeInstance.transform.position + translate, m_AwakeInstance.transform.rotation) as GameObject;
        GameObject patate2 = Instantiate(m_Sleeping, m_SleepingInstance.transform.position + translate, m_SleepingInstance.transform.rotation) as GameObject;
        
        m_AwakeInstance.GetComponent<SpriteRenderer>().enabled = false;
        m_SleepingInstance.GetComponent<SpriteRenderer>().enabled = true;

        snoring.Play();

        Vector3 godPosition = GameManager.Instance.m_MainCamera.ScreenToWorldPoint(m_SleepGod.m_Slider.transform.position);

        StartCoroutine(MoveFromTo(m_AwakeInstance.transform.position + translate, godPosition, 4.0f, patate));

        yield return new WaitForSeconds(2);

        m_AwakeInstance.GetComponent<SpriteRenderer>().enabled = true;
        m_SleepingInstance.GetComponent<SpriteRenderer>().enabled = false;
        if (m_SleepLevel >= 100)
		{
			m_SleepLevel = 100;
			StartCoroutine (FeelingFresh ());
		}

        if (player == false)
            m_SleepGod.Player1Favor(m_GodFavor);
        else if (player == true)
            m_SleepGod.Player2Favor(m_GodFavor);

        DestroyObject(patate2);
    }

	IEnumerator Attacking(bool player)
	{
		GameObject patate = Instantiate (m_Attacking, m_AwakeInstance.transform.position  + translate, m_AwakeInstance.transform.rotation) as GameObject;
		float statImportance = m_AttackLevel / 10f;
        float x = patate.transform.localScale.x * statImportance;
        float y = patate.transform.localScale.y * statImportance;
        patate.transform.localScale = new Vector3(x, y, 0f);

		Vector3 godPosition = GameManager.Instance.m_MainCamera.ScreenToWorldPoint(m_SaltGod.m_Slider.transform.position) + new Vector3(7f, 2.5f, 0) ;

		StartCoroutine (MoveFromTo (m_AwakeInstance.transform.position + translate, godPosition, 4.0f, patate));

		yield return new WaitForSeconds(2);

        if (player == false)
            m_SaltGod.Player1Favor(m_GodFavor);
        else if (player == true)
            m_SaltGod.Player2Favor(m_GodFavor);
    }

	IEnumerator Programming(bool player)
	{
		GameObject patate = Instantiate (m_Programming, m_AwakeInstance.transform.position  + translate, m_AwakeInstance.transform.rotation) as GameObject;
		float statImportance = m_ProgLevel / 10f;
        float x = patate.transform.localScale.x * statImportance;
        float y = patate.transform.localScale.y * statImportance;
        patate.transform.localScale = new Vector3(x, y, 0f);

		Vector3 godPosition = GameManager.Instance.m_MainCamera.ScreenToWorldPoint(m_ProgGod.m_Slider.transform.position);

        StartCoroutine (MoveFromTo (m_AwakeInstance.transform.position + translate, godPosition, 4.0f, patate));

		yield return new WaitForSeconds(2);

        if (player == false)
            m_ProgGod.Player1Favor(m_GodFavor);
        else if (player == true)
            m_ProgGod.Player2Favor(m_GodFavor);
    }

	IEnumerator Arting (bool player)
	{
		GameObject patate = Instantiate (m_Arting, m_AwakeInstance.transform.position  + translate, m_AwakeInstance.transform.rotation) as GameObject;
		float statImportance = m_ArtLevel / 10f;
        float x = patate.transform.localScale.x * statImportance;
        float y = patate.transform.localScale.y * statImportance;
        patate.transform.localScale = new Vector3(x, y, 0f);
        //    new Vector3 (1f * statImportance, 1f * statImportance, 0);

        Vector3 godPosition = GameManager.Instance.m_MainCamera.ScreenToWorldPoint(m_ArtGod.m_Slider.transform.position) + new Vector3(-7f, 2.5f, 0);

        StartCoroutine (MoveFromTo (m_AwakeInstance.transform.position + translate, godPosition, 4.0f, patate));

		yield return new WaitForSeconds(2);

        if (player == false)
            m_ArtGod.Player1Favor(m_GodFavor);
        else if (player == true)
            m_ArtGod.Player2Favor(m_GodFavor);
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
