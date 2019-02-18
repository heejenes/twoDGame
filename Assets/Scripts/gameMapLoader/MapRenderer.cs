using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapRenderer : MonoBehaviour {
    MapLoad loader;
    Tile[,] map;
    int xLength;
    int yLength;
    public float distTweenNodes;
    public GameObject colider;
    public SaveFormatEntity[] entitiesToLoad;

    ///////////////////////
    public GameObject characterObject, entityBox;


    private GameObject[] allEntities;
    private GameObject[] loadedEntities;
    private Entity[] loadedScripts;
    private int numOfEntities; //number of entities that need to be loaded.
    public GameObject entityContainer;



    void Start() {
        loader = new MapLoad();
        ExportLevel level = loader.loadMapArray(@"./Assets/Maps/map.rwm");
        map = level.tiles;

        xLength = map.GetLength(0);
        yLength = map.GetLength(1);

        /////
        entitiesToLoad = level.entities;
        entityContainer = GameObject.Find("/GameMap/Entity Container");

        numOfEntities = entitiesToLoad.Length;

        allEntities = new GameObject[1]{
            entityBox
        };

        loadedEntities = new GameObject[numOfEntities];

        for (int i=0; i<numOfEntities; i++){
            SaveFormatEntity curEntity = entitiesToLoad[i];
            loadedEntities[i] = Instantiate(
                allEntities[curEntity.entityId],
                new Vector3(curEntity.xPos, curEntity.yPos, -2),
                entityContainer.transform.rotation, 
                entityContainer.transform
            );
        }
        //loadedScripts will run parallel to loadedEntities. loadedEntities[i]'s script will be loadedScripts[i]
        loadedScripts = new Entity[numOfEntities]; //polymorphism 
        for (int i=0; i<numOfEntities; i++){
            loadedScripts[i] = loadedEntities[i].GetComponent(typeof(Entity)) as Entity;
        }
        Instantiate(
            characterObject, 
            new Vector3(0,0,-2), 
            entityContainer.transform.rotation, 
            entityContainer.transform
        );
        /////

        RenderMap();
    }
    void RenderMap(){
        Debug.Log("rendering Map");
        for(int x=0; x<xLength;x++){
            for(int y=0; y<yLength;y++){
                float worldXPos = x*distTweenNodes;
                float worldYPos = y*distTweenNodes;
                Vector3 worldPos = new Vector3(worldXPos, worldYPos,0)+transform.position;
                map[x,y].curTileInstance = Instantiate(
                    GameObject.Find(@"/allTiles/"+map[x,y].tileId), 
                    worldPos, 
                    transform.rotation, 
                    transform);
                if (map[x,y].tileCol){
                    Instantiate(
                        colider,
                        worldPos,
                        transform.rotation,
                        map[x,y].curTileInstance.transform
                    );
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
