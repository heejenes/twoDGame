using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTile : MonoBehaviour {
	public GameObject test;
	public MapGrid grid;
	public GameObject objToPlace;
	public bool placeCol;
	public GameObject colliderA;
	public Quaternion objRotation;
	public Transform map;
	public Transform entityContainer;

	public Vector3 gridStartPoint;
	void Awake () {
		//gridStartPoint = transform.position; 
		grid.setMapGrid(gridStartPoint, 10, 10, 1);
	}

	public void setObjToPlace (GameObject obj){
		this.objToPlace = obj;
	}
	public void setPlaceCol (bool _placeCol){
		this.placeCol = _placeCol;
	}
	public void setMap (Transform newMap) {
		this.map = newMap;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("place button pressed");
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast (ray, out hitInfo); 

			Vector3 pointPos = grid.nearestGridPoint(hitInfo.point);
			int[] coords = grid.vectorToCoords(pointPos);

			string objId = grid.getTile(coords).tileId.name;
			
			if (objToPlace.tag=="tileObj"){
				//Instantiate(objToPlace, pointToPlace, objRotation, map);
				if (placeCol & grid.getTile(coords).entityId != null){
					Debug.Log("Cannot place colider under entity");
				}
				else{
					Debug.Log("placing tile");
					if (objId != "emptyTile"){
						grid.getDestroyObj(coords);
						Debug.Log(objId + " was destroyed");
					}

					grid.getSetObj(coords, new TileObj(objToPlace, placeCol, grid.getTile(coords).entityId));

					GameObject newObj = grid.getCreateObj(pointPos, objToPlace, objRotation, map);
					if (placeCol){//to create a collider on top of the new tile
						grid.getCreateObj(pointPos, colliderA, objRotation, newObj.transform);
						Debug.Log("placed colider");
					}
				}
			}
			else if(objToPlace.tag == "entityObj"){
				Debug.Log("placing Entity");
				if (objId != null){
					grid.getDestroyEntity(coords);
					Debug.Log(objId + "'s entity was destroyed");
				}
				if (!grid.getTile(coords).tileCol){
					grid.getSetObj(coords, new TileObj(grid.getTile(coords).tileId, false, objToPlace));
					grid.getCreateEntity(pointPos+new Vector3(0,0, -1), objToPlace, objRotation, entityContainer);
				}
				else {
					Debug.Log("Cannot place entity on a collider!");
				}
			}
			else{Debug.Log("neither");}

			//Debug.Log(hitInfo.point);
			//WriteTo(mapFile.txt, objId, posInArray, objRotation);
		
		}
		
	}
}
