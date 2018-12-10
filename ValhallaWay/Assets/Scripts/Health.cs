using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    public TextMeshProUGUI lifeText = new TextMeshProUGUI();
    public GameObject deathScreen;
    private float hp;
    [HideInInspector]
    public float maxHP = 10;
    public bool isInvencible = false;

    private void Awake()
    {
        deathScreen.SetActive(false);
    }

    public float HP {
        get {
            return hp;
        }

        set {
            hp = value;
            lifeText.text = value.ToString();
        }
    }

    public void DealDamage(float damage) {
        if (!isInvencible) {
            StartCoroutine(SetInvencible(1f));
            HP -= damage;
            isDead();
        }
    }

    public void Heal(float cureAmount) {
        if(HP + cureAmount > maxHP) {
            HP = maxHP;
        } else {
            HP += cureAmount;
        }
    }
    
    public bool isDead()
    {
        if (HP <= 0)
        {
            Kill();
            return true;
        }
        return false;
    }
    
    public void Kill()
    {
        HP = 0;
        deathScreen.SetActive(true);
    }

    public void Save()
    {
        HP = maxHP;
        deathScreen.SetActive(false);
    }

    private IEnumerator SetInvencible(float time) {
        isInvencible = true;
        yield return new WaitForSeconds(time);
        isInvencible = false;
    }
}
