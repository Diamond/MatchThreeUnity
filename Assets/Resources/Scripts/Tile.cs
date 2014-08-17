using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	private bool _isTouched;
	public Transform tileController;
	public TileController tcScript;

	void Start()
	{
		_isTouched = false;
	}

	void OnMouseDown() {
		tcScript.selectedTile = this;
	}
}
