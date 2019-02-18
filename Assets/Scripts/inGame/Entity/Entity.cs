using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int entityId;
    float moveSpeed;
    float attackDamage;
    float hitPoints;
    float armor; //armor will start at 1.0 and debuffs can reduce it.
    
    public Entity(float _moveSpeed = 0, float _attackDamage = 0, float _hitPoints = 100, float _armor = 1){
        moveSpeed = _moveSpeed;
        attackDamage = _attackDamage;
        hitPoints = _hitPoints;
        armor = _armor;
    }

    public virtual void Attack(){
        Debug.Log("base entity attack");
    }
    public virtual void TakeDamage(){
        Debug.Log("base entity taking damage");
    }
}
