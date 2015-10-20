using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	static public GameController Instance{ get; private set;}

	void Awake()

	{
		if (Instance == null) {
			Instance = this;
		}
	}

	[SerializeField]
	PlayerMove player;

	public bool IsDead = false;
	public bool IsSageClear = false;

	void Start () 
	{
		StartCoroutine (GameFlow ());
	}

	IEnumerator GameFlow()
	{

		while (IsDead == false && IsSageClear == false) {
			yield return null;
		}

		yield return new WaitForSeconds(2);

		Application.LoadLevel (0);
	}
}
