using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileController : MonoBehaviour {
	public Transform tilePrefab;

	public List<Transform> tiles;

	// Use this for initialization
	void Start () {
		tiles = new List<Transform>();
		for (int y = 0; y < 15; y++) {
			for (int x = 0; x < 8; x++) {
				var newTile = Instantiate(tilePrefab) as Transform;
				float startX = -2.35f;
				float startY = 4.64f;
				float size   = 0.67f;
				newTile.position = new Vector3(startX + (size * x), startY + (size * y), 1);
				tiles.Add(newTile);
			}
		}
	}
}
