using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    
    public Vector2Int gridPos;
	public string tileId;
	public GameObject curTileInstance;
    public bool tileCol;
   /*
	public List<GameObject> occupants;
	public Tile neighbours; 
*/

    public Tile (Vector2Int _gridPos, string _tileId, bool _tileCol) {
        this.gridPos = _gridPos;
        this.tileId = _tileId;
        this.tileCol = _tileCol;
        //this.neighbours = _neighbours ?? new Tile[0]; 
        //https://stackoverflow.com/questions/446835/what-do-two-question-marks-together-mean-in-c
        
        //this.occupants = new List<GameObject>();
    }

}
