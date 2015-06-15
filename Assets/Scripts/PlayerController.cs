using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	#region Public Members
	public float Speed = 1.0f;
	public string InputName;
	#endregion

	#region Private Members
	private float _VertAxis = 0.0f;
	private Rigidbody2D _RB;
	private int _Score = 0;
	#endregion

	#region Properties
	public int Score
	{
		get { return _Score; }
		set { _Score = value; }
	}
	#endregion
	// Use this for initialization
	void Start () 
	{
		_RB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_VertAxis = Input.GetAxis (InputName);
	}

	void FixedUpdate()
	{
		_RB.velocity = _VertAxis * Speed * Vector2.up;
	}
}
