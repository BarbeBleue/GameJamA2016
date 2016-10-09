using UnityEngine;
using System.Collections;

public class ProgCharacter : BaseCharacter {

    public Animator anim;

    override public void Init () {

		m_ArtLevel = 1;
		m_ProgLevel = 10;
		m_AttackLevel = 5;
		m_SleepResist = 3;

        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    override public void Panic()
    {

        StartCoroutine(panicUnpanic());

    }

    IEnumerator panicUnpanic()
    {
        anim.SetBool("ProgrammerProblem", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("ProgrammerProblem", false);
    }

    /*void Update () {
	
	}*/
}
