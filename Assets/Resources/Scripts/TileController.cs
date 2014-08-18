using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileController : MonoBehaviour {
	public Transform tilePrefab;

	public List<Transform> tiles;
	private Transform[,] _tileMap;

	private bool _isTouching = false;
	private Vector3 _startPosition;
	public Tile selectedTile;

	public float jitterCorrection = 0.5f;

	public bool waitingToUnlock = false;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
		_tileMap = new Transform[8,8];

		int randColor = 0;
		// RED
		Color newColor = new Color(1.0f, 0.0f, 0.0f);

		tiles = new List<Transform>();
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				var newTile = Instantiate(tilePrefab) as Transform;
				float startX = -2.35f;
				float startY = -1.0f;
				float size   = 0.67f;
				newTile.position = new Vector3(startX + (size * x), startY + (size * y), 1);
				randColor = Random.Range (0, 5);
				if (randColor == 1) {
					// GREEN
					newColor = new Color(0.0f, 1.0f, 0.0f);
				} else if (randColor == 2) {
					// BLUE
					newColor = new Color(0.0f, 0.0f, 1.0f);
				} else if (randColor == 3) {
					// PINK
					newColor = new Color(1.0f, 0.0f, 1.0f);
				} else if (randColor == 4) {
					// YELLOW
					newColor = new Color(1.0f, 1.0f, 0.0f);
				} else {
					// RED
					newColor = new Color(1.0f, 0.0f, 0.0f);
				}
				newTile.GetComponent<SpriteRenderer>().color = newColor;
				newTile.GetComponent<Tile>().tcScript = this;
				newTile.parent = this.transform;
				_tileMap[y,x] = newTile;
			}
		}
	}

	Vector2 GetRowAndColumn()
	{
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				if (_tileMap[y,x].GetComponent<Tile>() == selectedTile) {
					return new Vector2(x, y);
				}
			}
		}
		return Vector2.zero;
	}

	void LockGravity()
	{
		// LOCK COLUMN
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				_tileMap[y,x].rigidbody2D.isKinematic = true;
			}
		}
	}

	void UnlockGravity()
	{
		// LOCK COLUMN
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				_tileMap[y,x].rigidbody2D.isKinematic = false;
			}
		}
	}

	void SlideLeft(int row, int col)
	{
		Debug.Log ("Sliding Left");
		for (int x = 0; x < 8; x++) {
			_tileMap[row, x].GetComponent<Tile>().MoveLeft();
		}
	}

	void SlideRight(int row, int col)
	{
		Debug.Log ("Sliding Right");
		for (int x = 0; x < 8; x++) {
			_tileMap[row, x].GetComponent<Tile>().MoveRight();
		}
	}

	void SlideUp(int row, int col)
	{

	}

	void SlideDown(int row, int col)
	{

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			if (!_isTouching) {
				_isTouching = true;
				_startPosition = Input.mousePosition;
				LockGravity();
			}
		}
		if (_isTouching && Input.mousePosition != _startPosition) {
			Vector3 newPosition = Input.mousePosition;
			if (newPosition.y > _startPosition.y) {
				Vector2 rowAndCol = GetRowAndColumn();
				// Move down
				float dy = Mathf.Abs(newPosition.y - _startPosition.y);
				if (dy > jitterCorrection) {
					Debug.Log ("up");
				}
			}
			if (newPosition.y < _startPosition.y) {
				Vector2 rowAndCol = GetRowAndColumn();
				// Move up
				float dy = Mathf.Abs(newPosition.y - _startPosition.y);
				if (dy > jitterCorrection) {
					Debug.Log ("down");
				}
			}
			if (newPosition.x < _startPosition.x) {
				Vector2 rowAndCol = GetRowAndColumn();
				// Move left
				float dx = Mathf.Abs(newPosition.x - _startPosition.x);
				if (dx > jitterCorrection) {
					Debug.Log ("Preparing to move at (" + (rowAndCol.x).ToString() + "," + (rowAndCol.y).ToString());
					SlideLeft ((int)rowAndCol.y, (int)rowAndCol.x);
				}
			}
			if (newPosition.x > _startPosition.x) {
				Vector2 rowAndCol = GetRowAndColumn();
				// Move right
				float dx = Mathf.Abs(newPosition.x - _startPosition.x);
				if (dx > jitterCorrection) {
					Debug.Log ("Right");
					SlideRight ((int)rowAndCol.y, (int)rowAndCol.x);
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			if (_isTouching) {
				_isTouching = false;
				waitingToUnlock = true;
				StopAllMoving();
			}
		}
		if (waitingToUnlock) {
			if (SafeToMove()) {
				waitingToUnlock = false;
				UnlockGravity();
			}
		}
	}

	public void StopAllMoving()
	{
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				_tileMap[y,x].GetComponent<Tile>().StopMoving();
			}
		}
	}

	bool SafeToMove()
	{
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				if (_tileMap[y,x].GetComponent<Tile>().IsMoving ()) {
					return false;
				}
			}
		}
		return true;
	}
}
