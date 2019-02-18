using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObj {

	public GameObject tileId;
	public GameObject curTileInstance;
	public GameObject entityId;
	public GameObject curEntityInstance;
	//public int walkSpeed;
	public bool tileCol;

	public TileObj(GameObject _tileId, /*int _walkSpeed,*/ bool _tileCol, GameObject _entityId = null){
		tileId = _tileId;
		//walkSpeed = _walkSpeed;
		tileCol = _tileCol;
		entityId = _entityId;
		//updateTile();
	}

	//private void updateTile(){}
}
