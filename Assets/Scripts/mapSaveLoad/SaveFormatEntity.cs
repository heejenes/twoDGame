using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFormatEntity {
    public int xPos;
    public int yPos;
    public int entityId;
    public SaveFormatEntity(int _xPos, int _yPos, int _entityId){
        xPos = _xPos;
        yPos = _yPos;
        entityId = _entityId;
    }
}