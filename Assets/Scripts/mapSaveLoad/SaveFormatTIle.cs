using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //https://docs.microsoft.com/en-us/dotnet/standard/serialization/custom-serialization
public class SaveFormatTile{
    public string tileId;
    public int? entityId;
    public int posX;
    public int posY;
    public bool tileCol;
    public SaveFormatTile(string _tileId, int _posX, int _posY, bool _tileCol, int? _entityId = null){
        this.tileId = _tileId;
        this.entityId = _entityId;
        this.posX = _posX;
        this.posY = _posY;
        this.tileCol = _tileCol;
    }
}