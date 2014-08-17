using UnityEngine;
using System.Collections;

public class FeelerScript : MonoBehaviour {
	public Transform owner;
	private Tile _ownerTile;

	void Start()
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
	}

	void OnTriggerStay2D(Collider2D c)
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
		if (c.gameObject.tag == "Box") {
			_ownerTile.AddNeighbor(c.GetComponent<Tile>());
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
		if (c.gameObject.tag == "Box") {
			_ownerTile.AddNeighbor(c.GetComponent<Tile>());
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
		if (c.gameObject.tag == "Box") {
			_ownerTile.RemoveNeighbor(c.GetComponent<Tile>());
		}
	}
}
