﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileController : MonoBehaviour {
	public Transform tilePrefab;

	public List<Transform> tiles;

	private bool _isTouching = false;
	private Vector3 _startPosition;
	public Tile selectedTile;

	public float jitterCorrection = 0.5f;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;

		int randColor = 0;
		// RED
		Color newColor = new Color(1.0f, 0.0f, 0.0f);

		tiles = new List<Transform>();
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				var newTile = Instantiate(tilePrefab) as Transform;
				float startX = -2.35f;
				float startY = 2.5f;
				float size   = 0.67f;
				newTile.position = new Vector3(startX + (size * x), startY + (size * y), 1);
				randColor = Random.Range (0, 4);
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
				tiles.Add(newTile);
			}
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			if (!_isTouching) {
				_isTouching = true;
				_startPosition = Input.mousePosition;
			}
		}
		if (_isTouching && Input.mousePosition != _startPosition) {
			Vector3 newPosition = Input.mousePosition;
			if (newPosition.y > _startPosition.y) {
				// Move down

				float dy = Mathf.Abs(newPosition.y - _startPosition.y);
				if (dy > jitterCorrection) {
					Debug.Log ("up");
				}
			}
			if (newPosition.y < _startPosition.y) {
				// Move up
				float dy = Mathf.Abs(newPosition.y - _startPosition.y);
				if (dy > jitterCorrection) {
					Debug.Log ("down");
				}
			}
			if (newPosition.x < _startPosition.x) {
				// Move left
				float dx = Mathf.Abs(newPosition.x - _startPosition.x);
				if (dx > jitterCorrection) {
					Debug.Log ("Left");
				}
			}
			if (newPosition.x > _startPosition.x) {
				// Move right
				float dx = Mathf.Abs(newPosition.x - _startPosition.x);
				if (dx > jitterCorrection) {
					Debug.Log ("Right");
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			if (_isTouching) {
				_isTouching = false;
			}
		}
	}
}
