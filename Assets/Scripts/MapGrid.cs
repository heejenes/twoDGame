using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour {

	public Vector3 startingPoint;
	public int arraySizeX;
	public int arraySizeY;
	public int distTweenNodes;
	public TileObj[,] mapArray;
	public GameObject defaultTile;

	public void setMapGrid(Vector3 _startingPoint, int _arraySizeX, int _arraySizeY, int _distTweenNodes) {
		this.startingPoint = _startingPoint;
		this.arraySizeX = _arraySizeX;
		this.arraySizeY = _arraySizeY;
		this.distTweenNodes = _distTweenNodes;
		
		mapArray = new TileObj[arraySizeY, arraySizeX];
		fillGrid();
	}

	public void getSetObj(Vector3 point, TileObj newData) {
		int[] coords = vectorToCoords(point);
		Debug.Log(mapArray[0,0].tileId.name);
		this.mapArray[coords[1], coords[0]] = newData;
	}
	public void getCreateObj(Vector3 point, GameObject objToPlace, Quaternion rotation, Transform map){
		int[] coords = vectorToCoords(point);
		GameObject newTile = Instantiate(objToPlace, point, rotation, map);
		mapArray[coords[1], coords[0]].curTileInstance = newTile;
	}
	public void getDestroyObj(Vector3 point) {
		int[] coords = vectorToCoords(point);
		Debug.Log(mapArray[0,0].tileId.name);
		Destroy(this.mapArray[coords[1], coords[0]].curTileInstance);
	}
	public string getObjName(Vector3 point) {
		int[] coords = vectorToCoords(point);
		Debug.Log(mapArray[0,0].tileId.name);
		return this.mapArray[coords[1], coords[0]].tileId.name;
	}

	public Vector3 nearestGridPoint(Vector3 point) {
		int[] coords = vectorToCoords(point);

		return startingPoint + new Vector3(coords[0]*distTweenNodes, coords[1] * distTweenNodes, transform.position.z);
	}

	private int[] vectorToCoords(Vector3 point) {
		int x = Mathf.RoundToInt(point.x/distTweenNodes);
		int y = Mathf.RoundToInt(point.y/distTweenNodes);
		
		if (x < 0){ //if out of range on the y axis
			x = 0;
		}
		else if (x >= arraySizeX){
			x = arraySizeX-1;
		}

		if (y < 0){ //if out of range on the y axis
			y = 0;
		}
		else if (y >= arraySizeY){
			y = arraySizeY-1;
		}
		int[] final = {x, y};
		return final;
	}
	void fillGrid() {
		for (int y = 0; y < arraySizeY; y++) {
			for (int x = 0; x < arraySizeX; x++) {
				TileObj node = new TileObj(defaultTile, 100, false);
				mapArray[y, x] = node;
			}
		}
	}
}
