﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public int hitsToKill;
	public int points;
	private int numberOfHits;

	// Use this for initialization
	void Start () 
	{
		numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
			numberOfHits++;

			if(numberOfHits == hitsToKill)
			{
				PlayerProgressManager.Instance.addPoints(points);
				PlayerProgressManager.Instance.checkWin();
				Destroy(this.gameObject);
			}
		}
	}
}
