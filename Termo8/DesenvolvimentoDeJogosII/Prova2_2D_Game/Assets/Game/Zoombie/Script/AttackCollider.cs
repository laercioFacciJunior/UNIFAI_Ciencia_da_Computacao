using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        attackTime = attackTime + Time.deltaTime;

            if(attackTime >=1 )
            {
                attackTime = 0;
                if(collision.CompareTag("player"))
                {
                    collision.GetComponent<Character>().life--;
                    Debug.Log("dano");
                }
            }
        
    }
}
