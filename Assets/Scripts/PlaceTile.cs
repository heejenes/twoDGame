using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTile : MonoBehaviour {
	public GameObject test;
	public MapGrid grid;
	public GameObject objToPlace;
	public Quaternion objRotation;
	public Transform map;

	public Vector3 gridStartPoint; 
	void Awake () {
		grid.setMapGrid(gridStartPoint, 10, 10, 1);
	}

	public void setObjToPlace (GameObject obj){
		this.objToPlace = obj;
	}
	public void setObjRotation (Quaternion rotation){
		this.objRotation = rotation;
	}
	public void setMap (Transform newMap) {
		this.map = newMap;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast (ray, out hitInfo);

			Vector3 pointPos = grid.nearestGridPoint(hitInfo.point);

			string objId = grid.getObjName(hitInfo.point);
			//Instantiate(objToPlace, pointToPlace, objRotation, map);
			Debug.Log(objId);
			if (objId != "emptyTile"){
				grid.getDestroyObj(hitInfo.point);
				Debug.Log(objId + " was destroyed");
			}

			grid.getSetObj(hitInfo.point, new TileObj(objToPlace, 100, false));

			grid.getCreateObj(pointPos, objToPlace, objRotation, map);

			//Debug.Log(hitInfo.point);
			//WriteTo(mapFile.txt, objId, posInArray, objRotation);
		
		}
		
	}
}
