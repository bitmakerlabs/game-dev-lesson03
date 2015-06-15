using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	#region Public Members
	public float InitialSpeed = 3.0f;
	public float SpeedIncRate = 0.25f;
	public PlayerController [] Players;

	#endregion

	#region Private Members
	private Vector2 _InitPosition;
	private Rigidbody2D _RB;
	private Vector2 _Velocity;
	private float _Speed = 0.0f;
	#endregion
	// Use this for initialization
	void Start () 
	{
		_InitPosition = this.transform.position;
		_RB = GetComponent<Rigidbody2D> ();

		// randomly assign a direction to the velocity
		_Velocity = Random.insideUnitCircle.normalized * InitialSpeed;
		_RB.velocity = _Velocity;

		_Speed = InitialSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_Speed += Time.deltaTime*SpeedIncRate;
	}

	#region Unity Events
	private void OnCollisionEnter2D(Collision2D col)
	{
		// if we collide with the environment, reflect our velocity on a perpendicular angle
		if (col.collider.CompareTag ("Environment")) 
		{
			_Velocity = new Vector2(_Velocity.x, -_Velocity.y);
			_Velocity = _Velocity.normalized * _Speed;

			_RB.velocity = _Velocity;
		}
		// if we collide with the player, reflect our velocity based on where we collided
		else if (col.collider.CompareTag ("Player")) 
		{
			float rand = Random.Range (0.4f, 1.0f);
			float sign = Mathf.Sign (_Velocity.y);

			_Velocity = new Vector2(-_Velocity.normalized.x, (_Velocity.normalized.y + sign*0.1f)*rand)*_Speed;
			_RB.velocity = _Velocity;
		}
	}

	private void _BallOutOfBounds(int playerNumber)
	{
		_RB.MovePosition(_InitPosition);			
		_Velocity = Random.insideUnitCircle.normalized * InitialSpeed;
		_RB.velocity = _Velocity;
		_Speed = InitialSpeed;
		
		Players[playerNumber].Score += 1;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if( col.CompareTag("DeathZone"))
		{
			if( col.name == "DeathZone1" )
			{
				_BallOutOfBounds(1);
			}
			else if( col.name == "DeathZone2")
			{
				_BallOutOfBounds(0);
			}
		}
	}
	#endregion
}
