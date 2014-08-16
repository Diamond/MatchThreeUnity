using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	private bool _isTouched;
	public Transform tileController;
	private TileController _tcScript;

	void Start()
	{
		_isTouched = false;
		_tcScript = tileController.GetComponent<TileController>();
	}

	void OnMouseDown() {
		Debug.Log ("i have been touched");
	}
}
