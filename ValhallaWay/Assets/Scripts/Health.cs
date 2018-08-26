﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private float hp;
    [HideInInspector]
    public float maxHP = 10;
    public bool isInvencible = false;

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
        yield return new WaitForSeconds(time);
        isInvencible = false;

    }
}
