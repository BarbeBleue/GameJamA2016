using UnityEngine;
using System.Collections;

public class ArtCharacter : BaseCharacter {

    public Animator anim;

    override public void Init () {
		
		m_ArtLevel = 10;
		m_ProgLevel = 4;
		m_AttackLevel = 2;
		m_SleepResist = 3;

        anim = m_AwakeInstance.GetComponent(typeof(Animator)) as Animator;

    }

    override public void Panic()
    {

        StartCoroutine(panicUnpanic());

    }

    IEnumerator panicUnpanic()
    {
        anim.SetBool("ArtistProblem", true);
        yield return new WaitForSeconds(4);
        anim.SetBool("ArtistProblem", false);
    }

    /*void Update () {
	
	}*/
}
