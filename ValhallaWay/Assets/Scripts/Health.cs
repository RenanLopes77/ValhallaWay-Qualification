using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    public TextMeshProUGUI lifeText = new TextMeshProUGUI();
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
            lifeText.text = value.ToString();
        }
    }

    public void DealDamage(float damage) {
        if (!isInvencible) {
            StartCoroutine(SetInvencible(1f));
            HP -= damage;
        }
    }

    public void Heal(float cureAmount) {
        if(HP + cureAmount > maxHP) {
            HP = maxHP;
        } else {
            HP += cureAmount;
        }
    }

    private IEnumerator SetInvencible(float time) {
        isInvencible = true;
        yield return new WaitForSeconds(time);
        isInvencible = false;
    }
}
