using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	private bool _isTouched;
	public TileController tcScript;
	public List<Tile> neighbors;

	public bool isMovingLeft = false;

	void Start()
	{
		_isTouched = false;
		neighbors = new List<Tile>();
	}

	void OnMouseDown() {
		tcScript.selectedTile = this;
	}

	public void MoveLeft() {
		isMovingLeft = true;
	}

	public void StopMoving()
	{
		isMovingLeft = false;
	}

	void Update()
	{
		float vel = 0.67f * Time.deltaTime * 2;
		if (isMovingLeft) {
			if (this.transform.position.x <= -2.35f) {
				this.transform.position = new Vector3(-2.35f + (8.0f * 0.67f), this.transform.position.y, 0.0f);
			}
			this.transform.position -= new Vector3(vel, 0.0f, 0.0f);
		}
	}

	public void AddNeighbor(Tile n)
	{
		if (!neighbors.Contains(n) && n != this) {
			neighbors.Add(n);
		}
	}

	public void RemoveNeighbor(Tile n)
	{
		if (neighbors.Contains(n)) {
			neighbors.Remove(n);
		}
	}
}
