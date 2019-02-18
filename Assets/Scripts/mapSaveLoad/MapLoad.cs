using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MapLoad {
    //public MapGrid grid;
    public void formatSaveMapArray(TileObj[,] mapArray){
        int sizeX = mapArray.GetLength(0);
        int sizeY = mapArray.GetLength(1);// a complete mess with different array rotations

        SaveFormatTile[] finalList;
        int lenToMakeList = 0;
        int numOfEntities = 0;

        for (int x=0; x<sizeX; x++){//preps 1d array
            for (int y=0; y<sizeY; y++){
                if (mapArray[x,y].tileId.name != "emptyTile"){
                    lenToMakeList++; // so make the list long enough to hold all filled tiles.
                }
                Debug.Log(mapArray[x,y].entityId);
                if (mapArray[x,y].entityId != null){
                    numOfEntities++;
                }
            }
        }
        finalList = new SaveFormatTile[lenToMakeList+1];
        finalList[0] = new SaveFormatTile("mapone", sizeX, sizeY, false, numOfEntities); //first item will define the size and name of 2Darray
        int finalIndex = 1;
        

        for (int x=0; x<sizeX; x++){
            for (int y=0; y<sizeY; y++){
                if (mapArray[x,y].curEntityInstance != null){
                    Entity curEntity = mapArray[x,y].curEntityInstance.GetComponent(typeof(Entity)) as Entity;
                    if (mapArray[x,y].tileId.name != "emptyTile"){
                        finalList[finalIndex] = new SaveFormatTile(
                            mapArray[x,y].tileId.name, 
                            x, 
                            y, 
                            mapArray[x,y].tileCol,
                            curEntity.entityId
                        );
                        finalIndex++;
                    }//cycle through 2d array and convert to 1d array               
                }
                else if (mapArray[x,y].tileId.name != "emptyTile"){
                    finalList[finalIndex] = new SaveFormatTile(
                        mapArray[x,y].tileId.name, 
                        x, 
                        y, 
                        mapArray[x,y].tileCol
                    );
                    finalIndex++;
                
                }

            }
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create ("./Assets/Maps/map.rwm");
        bf.Serialize(file, finalList);
        file.Close();
    }

    public ExportLevel loadMapArray(string mapDirectory) { 
      

        if(File.Exists(mapDirectory)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(mapDirectory, FileMode.Open);

            SaveFormatTile[] finalList = bf.Deserialize(file) as SaveFormatTile[];
           
            int gridSizeX = finalList[0].posX;
            int gridSizeY = finalList[0].posY;
            int numOfEntities = (int)finalList[0].entityId;
            Debug.Log("number of eneityies");
            Debug.Log(numOfEntities);
            Tile[,] tiles = new Tile[gridSizeX, gridSizeY];
            SaveFormatEntity[] entitiesToLoad = new SaveFormatEntity[numOfEntities];

            int finalIndex = 1;
            int entityIndex = 0;
            for (int x=0; x<gridSizeX; x++){//takes finalList and puts it back into 2d array form
                for (int y=0; y<gridSizeY; y++){

                    if (finalList[finalIndex].entityId != null){
                        Debug.Log("entityIndex is: ");
                        Debug.Log(entityIndex);
                        Debug.Log(finalIndex);
                        entitiesToLoad[entityIndex] = new SaveFormatEntity(
                            x,
                            y,
                            (int)finalList[finalIndex].entityId
                        );
                        
                        entityIndex++;
                    }

                    if (finalList[finalIndex].posX == x & finalList[finalIndex].posY == y) {
                        tiles[x, y] = new Tile(new Vector2Int(x, y), finalList[finalIndex].tileId, finalList[finalIndex].tileCol);
                        finalIndex ++;
                    }
                    else {
                        tiles[x, y] = new Tile(new Vector2Int(x, y), "emptyTile", false);
                    }
                }
            }
            
          
            file.Close();

            return new ExportLevel(tiles, entitiesToLoad);

        }
        else{
            Debug.Log("Map doesnt exist");
            Tile[,] tiles = new Tile[1, 1];
            SaveFormatEntity[] entities = new SaveFormatEntity[1];
            return new ExportLevel(tiles, entities);
        }
    }
}
public class ExportLevel{
    public Tile[,] tiles;
    public SaveFormatEntity[] entities;
    public ExportLevel(Tile[,] tile, SaveFormatEntity[] entity){
        tiles = tile;
        entities = entity;
    }
}