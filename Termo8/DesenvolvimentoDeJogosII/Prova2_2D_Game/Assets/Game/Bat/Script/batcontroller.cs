using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batcontroller : MonoBehaviour
{
    public Transform player;

    public float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > 2.5)
        {
            attackTime = 0;

            transform.position = Vector2.MoveTowards(transform.position, player.position, 3 * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;

            if(attackTime >=1 )
            {
                attackTime = 0;
                player.GetComponent<Character>().life--;
            }
        }

        if(GetComponent<Character>().life <=0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            this.enabled = false;
        }
    }
}
