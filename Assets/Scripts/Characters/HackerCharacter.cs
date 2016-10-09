using UnityEngine;
using System.Collections;

public class HackerCharacter : BaseCharacter {

    public Animator anim;

    override public void Init () {

		m_ArtLevel = 1;
		m_ProgLevel = 5;
		m_AttackLevel = 10;
		m_SleepResist = 5;

        anim = m_AwakeInstance.GetComponent(typeof(Animator)) as Animator;

    }

    override public void Panic()
    {

        StartCoroutine(panicUnpanic());

    }

    IEnumerator panicUnpanic()
    {
        anim.SetBool("HackerProblem", true);
        yield return new WaitForSeconds(4);
        anim.SetBool("HackerProblem", false);
    }

    /*void Update () {
	
	}*/
}
