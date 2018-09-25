using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObj {

	public GameObject tileId;
	public GameObject curTileInstance;
	public int walkSpeed;
	public bool tileCol;

	public TileObj(GameObject _tileId, int _walkSpeed, bool _tileCol){
		tileId = _tileId;
		walkSpeed = _walkSpeed;
		tileCol = _tileCol;
		//updateTile();
	}

	//private void updateTile(){}
}
