using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float playerVelocity;
	public float boundary;
	private Vector3 playerPosition;

	// Use this for initialization
	void Start () 
	{
		boundary = GameObject.Find("Background").GetComponent<SpriteRenderer>().bounds.size.x/2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2;
		playerPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_EDITOR

			playerPosition.x += Input.GetAxis("Horizontal")*playerVelocity;

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}

		#endif

		#if UNITY_ANDROID
		if(Time.timeScale != 0)
		{
			if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)) 
			{
				if(transform.position.x < boundary || transform.position.x > -boundary)
				{
					if(Input.GetTouch(0).position.x < Screen.width/2)
					{
						playerPosition.x -= playerVelocity;
					}
					else if(Input.GetTouch(0).position.x > Screen.width/2) 
					{
						playerPosition.x += playerVelocity;
					}
				}
			}
			else
			{
				if(Input.acceleration.x > 0.02f || Input.acceleration.x < -0.02f)
				{
					playerPosition.x += Input.acceleration.x*playerVelocity*4;
				}
			}
		}
		#endif

		if (playerPosition.x < -boundary) 
		{
			playerPosition = new Vector3 (-boundary, playerPosition.y, playerPosition.z);
		} 
		if (playerPosition.x > boundary) 
		{
			playerPosition = new Vector3(boundary, playerPosition.y, playerPosition.z); 
		}

		transform.position = playerPosition;
	}
}
