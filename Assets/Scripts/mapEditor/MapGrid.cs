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
		
		mapArray = new TileObj[arraySizeX, arraySizeY];
		fillGrid();
	}

	public void getSetObj(int[] coords, TileObj newData) {
		//int[] coords = vectorToCoords(point);
		//Debug.Log(mapArray[0,0].tileId.name);
		this.mapArray[coords[0], coords[1]] = newData;
	}
	public GameObject getCreateObj(Vector3 point, GameObject objToPlace, Quaternion rotation, Transform map){
		int[] coords = vectorToCoords(point);
		GameObject newTile = Instantiate(objToPlace, point, rotation, map);
		mapArray[coords[0], coords[1]].curTileInstance = newTile;
		return newTile;
	}
	public GameObject getCreateEntity(Vector3 point, GameObject objToPlace, Quaternion rotation, Transform container){
		int[] coords = vectorToCoords(point);
		GameObject newTile = Instantiate(objToPlace, point, rotation, container);
		mapArray[coords[0], coords[1]].curEntityInstance = newTile;
		return newTile;
	}
	public void getDestroyObj(int[] coords) {//doesnt work to replace stone for some reason
		//int[] coords = vectorToCoords(point);
		//Debug.Log(mapArray[0,0].tileId.name);
		Destroy(this.mapArray[coords[0], coords[1]].curTileInstance);
	}
	public void getDestroyEntity(int[] coords){
		Destroy(this.mapArray[coords[0], coords[1]].curEntityInstance);
	}
	/*
	public string getObjName(int[] coords) {
		//int[] coords = vectorToCoords(point);
		//Debug.Log(mapArray[0,0].tileId.name);
		return this.mapArray[coords[0], coords[1]].tileId.name;
	}*/

	public Vector3 nearestGridPoint(Vector3 point) {
		int[] coords = vectorToCoords(point);

		return startingPoint + new Vector3(coords[0]*distTweenNodes, coords[1] * distTweenNodes, transform.position.z);
	}
	public TileObj getTile(int[] coords){
		return this.mapArray[coords[0], coords[1]];
	}

	public int[] vectorToCoords(Vector3 point) {
		int x = Mathf.RoundToInt((point.x-startingPoint.x)/distTweenNodes);
		int y = Mathf.RoundToInt((point.y-startingPoint.y)/distTweenNodes);
		
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
		for (int x = 0; x < arraySizeX; x++) {
			for (int y = 0; y < arraySizeY; y++) {
				TileObj node = new TileObj(defaultTile, false, null);
				mapArray[x, y] = node;
			}
		}
	}
	public void saveMap(){
		new MapLoad().formatSaveMapArray(this.mapArray);
	}
}
