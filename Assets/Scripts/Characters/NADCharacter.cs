﻿using UnityEngine;
using System.Collections;

public class NADCharacter : BaseCharacter {

    public Animator anim;

    override public void Init () {

		m_ArtLevel = 6;
		m_ProgLevel = 5;
		m_AttackLevel = 5;
		m_SleepResist = 2;

        anim = m_AwakeInstance.GetComponent(typeof(Animator)) as Animator;

    }

    override public void Panic()
    {

        StartCoroutine(panicUnpanic());
     
    }

    IEnumerator panicUnpanic()
    {
        anim.SetBool("GeneralistProblem", true);
        yield return new WaitForSeconds(4);
        anim.SetBool("GeneralistProblem", false);
    }

    /*void Update () {
	
	}*/
	// Jeremy was here! In fact, It's the only line of code I wrote the entire GameJam! Talk about a loser...
}
