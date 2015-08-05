using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public GameObject playerObject;
	public GameObject mainCamera;
	public bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;
	private float ballRadius;

	// Use this for initialization
	void Start () 
	{

	}

	void Update () 
	{
		#if UNITY_EDITOR

			if(Input.GetButtonDown("Jump") == true)
			{
				if(!ballIsActive)
				{
					GetComponent<Rigidbody2D>().isKinematic = false;
					GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
					ballIsActive = true;
				}
			}

		#endif

		#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) 
			{
				if(!ballIsActive)
				{
					GetComponent<Rigidbody2D>().isKinematic = false;
					GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
					ballIsActive = true;
				}
			}
		#endif

		if(!ballIsActive && playerObject != null)
		{
			ballPosition.x = playerObject.transform.position.x;
			transform.position = ballPosition;
		}

		if (ballIsActive && transform.position.y < playerObject.transform.position.y - ballRadius) 
		{
			Handheld.Vibrate();
			ballIsActive = false;
			ballPosition.x = playerObject.transform.position.x;
			ballPosition.y = playerObject.transform.position.y + ballRadius;
			transform.position = ballPosition;

			GetComponent<Rigidbody2D>().isKinematic = true;

			PlayerProgressManager.Instance.takeLife();
		}
	}

	public void setBallOnStartPosition()
	{
		GetComponent<Rigidbody2D>().isKinematic = false;
		ballRadius = GetComponent<CircleCollider2D>().radius;
		
		ballInitialForce = new Vector2(100.0f, 300.0f);
		ballIsActive = false;
		ballPosition = new Vector3(playerObject.transform.position.x,playerObject.transform.position.y + ballRadius, playerObject.transform.position.z);
		GetComponent<Rigidbody2D>().isKinematic = true;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (ballIsActive) 
		{
			SoundManager.instance.playHitSound();
		}
	}
}
