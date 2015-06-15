using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour 
{
	#region Public Members
	public PlayerController @PlayerController;
	#endregion

	#region Private Members
	private UnityEngine.UI.Text _Text;
	#endregion

	void Start()
	{
		_Text = GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_Text.text = this.PlayerController.Score.ToString ();
	}
}
