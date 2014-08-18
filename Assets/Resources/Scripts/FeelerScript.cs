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
			AddNeighbor(c.GetComponent<Tile>());
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
		if (c.gameObject.tag == "Box") {
			AddNeighbor(c.GetComponent<Tile>());
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		owner = this.transform.parent;
		_ownerTile = owner.GetComponent<Tile>();
		if (c.gameObject.tag == "Box") {
			RemoveNeighbor();
		}
	}

	void AddNeighbor(Tile t) {
		if (this.tag == "Left") {
			_ownerTile.leftNeighbor = t;
		} else if (this.tag == "Right") {
			_ownerTile.rightNeighbor = t;
		} else if (this.tag == "Top") {
			_ownerTile.topNeighbor = t;
		} else if (this.tag == "Bottom") {
			_ownerTile.bottomNeighbor = t;
		}
	}

	void RemoveNeighbor() {
		if (this.tag == "Left") {
			_ownerTile.leftNeighbor = null;
		} else if (this.tag == "Right") {
			_ownerTile.rightNeighbor = null;
		} else if (this.tag == "Top") {
			_ownerTile.topNeighbor = null;
		} else if (this.tag == "Bottom") {
			_ownerTile.bottomNeighbor = null;
		}
	}
}
