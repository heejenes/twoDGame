using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBox : Entity
{
    public static int entityId = 0;
    EntityBox(float _moveSpeed = 0, float _attackDamage = 0, float _hitPoints = 10, float _armor = 1): 
    base(_moveSpeed, _attackDamage, _hitPoints, _armor){
    }
    public override void Attack(){
        Debug.Log("box entity attack");
    }
    public override void TakeDamage(){
        Debug.Log("box entity taking damage");
    }
}
