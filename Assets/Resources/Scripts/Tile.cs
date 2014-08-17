using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	private bool _isTouched;
	public TileController tcScript;
	public List<Tile> neighbors;

	public bool isMovingLeft  = false;
	public bool isMovingRight = false;
	public bool isMovingUp    = false;
	public bool isMovingDown  = false;

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

	public void MoveRight() {
		isMovingRight = true;
	}

	public void StopMoving()
	{
		if (isMovingLeft) {
			int xMapPos = Mathf.Abs((int)((this.transform.position.x + 2.35f) / 0.67f));
			this.transform.position = new Vector3(-2.35f + (float)xMapPos * 0.67f, this.transform.position.y, this.transform.position.z);
			isMovingLeft = false;
			isMovingRight = false;
		}
		if (isMovingRight) {
			int xMapPos = Mathf.Abs((int)((this.transform.position.x + 2.35f + 0.335f) / 0.67f));
			this.transform.position = new Vector3(-2.35f + (float)xMapPos * 0.67f, this.transform.position.y, this.transform.position.z);
			isMovingLeft = false;
			isMovingRight = false;
		}
	}

	void PerformLeftMove()
	{
		float vel = 0.67f * Time.deltaTime * 2;
		if (this.transform.position.x <= -2.35f) {
			this.transform.position = new Vector3(-2.35f + (8.0f * 0.67f), this.transform.position.y, 0.0f);
		}
		this.transform.position -= new Vector3(vel, 0.0f, 0.0f);

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
		if (isMovingRight) {
			if (this.transform.position.x >= -2.35f + 7.0f * 0.67f) {
				this.transform.position = new Vector3(-2.35f, this.transform.position.y, 0.0f);
			}
			this.transform.position -= new Vector3(-vel, 0.0f, 0.0f);
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

	public Vector3 Center()
	{
		float cx = this.transform.position.x + 0.67f / 2.0f;
		float cy = this.transform.position.y + 0.67f / 2.0f;
		float cz = 0.0f;
		return new Vector3(cx, cy, cz);
	}

	public bool IsMoving()
	{
		return isMovingUp || isMovingRight || isMovingLeft || isMovingDown;
	}
}
