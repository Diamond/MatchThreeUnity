using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileController : MonoBehaviour {
	public Transform tilePrefab;

	public List<Transform> tiles;

	// Use this for initialization
	void Start () {
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
				tiles.Add(newTile);
			}
		}
	}
}
