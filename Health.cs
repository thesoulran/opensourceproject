using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {


    public const int maxHP = 100;
    public bool destroyOnDeath;

    public int currentHP = maxHP;
    public bool isEnemy = false;

    public RectTransform HPbar;

    private bool isLocalPlayer;

	void Start () {
        EonMoveSide pc = GetComponent<EonMoveSide>();
        isLocalPlayer = pc.isLocalPlayer;
	}
	
    public void TakeDamage(GameObject playerFrom, int amount)
    {
        currentHP -= amount;
        // TODO network

    }


    public void OnChangeHP()
    {
        HPbar.sizeDelta = new Vector2(currentHP, HPbar.sizeDelta.y);
        if(currentHP <= 0)
        {
            if(destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHP = maxHP;
                HPbar.sizeDelta = new Vector2(currentHP, HPbar.sizeDelta.y);
                Respawn();
            }
        }
    }

    void Respawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            transform.position = spawnPoint;
            
        }
    }
}
