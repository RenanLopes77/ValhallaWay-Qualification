using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private float hp;
    [HideInInspector]
    public float maxHP = 10;
    public bool isInvencible = false;
    //fazer corotina para deixar invencivel por x segundos após tomar dano

    public float HP {
        get {
            return hp;
        }

        set {
            hp = value;
        }
    }

    public void DealDamage(float damage) {
        if (!isInvencible) {
            StartCoroutine(SetInvencible(1f));
            hp -= damage;
        }
    }

    public void Heal(float cureAmount) {
        if(hp + cureAmount > maxHP) {
            hp = maxHP;
        } else {
            hp += cureAmount;
        }
    }

    private IEnumerator SetInvencible(float time) {
        isInvencible = true;
        Debug.Log("Invencivel!");
        yield return new WaitForSeconds(time);
        isInvencible = false;
        Debug.Log("Normal");

    }
}
