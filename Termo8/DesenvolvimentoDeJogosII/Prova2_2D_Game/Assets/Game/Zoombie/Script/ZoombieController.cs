using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoombieController : MonoBehaviour
{
    public Transform pontoA, pontoB;
    public Transform skin;
    public bool direita;
    public Transform range;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        if(GetComponent<Character>().life <=0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            range.GetComponent<CircleCollider2D>().enabled = false;
            this.enabled = false;
        }

        if (direita == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector3.Distance(transform.position, pontoB.position) < 1f)
            {
                direita = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, pontoB.position, 5 * Time.deltaTime);
            //movimentar da posicao atual para pontoB
        }

        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector3.Distance(transform.position, pontoA.position) < 1f)
            {
                direita = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, pontoA.position, 5 * Time.deltaTime);
            //movimentar da posicao atual para pontoA
        }

        
    }
}
