/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLoader : MonoBehaviour
{
    public GameObject characterObject, entityBox;


    private GameObject[] allEntities;
    private SaveFormatEntity[] entitiesToLoad;
    private GameObject[] loadedEntities;
    private Entity[] loadedScripts;
    private int numOfEntities; //number of entities that need to be loaded.

    public GameObject entityContainer;


    public EntityLoader(SaveFormatEntity[] entities){
        entitiesToLoad = entities;
        entityContainer = GameObject.Find("Entity Container");

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
    }
}
*/