using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoombieController : MonoBehaviour
{
    public Transform pontoA, pontoB;
    public Transform skin;
    public bool direita; //variável para controlar direção

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //controlando a direção do inimigo (entre os pontos)
        if (direita == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector3.Distance(transform.position, pontoB.position) < 1f)
            {
                direita = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, pontoB.position, 5 * Time.deltaTime);
            //movimentar da posição atual para pontoB
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector3.Distance(transform.position, pontoA.position) < 1f)
            {
                direita = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, pontoA.position, 5 * Time.deltaTime);
            //movimentar da posição atual para pontoA
        }
    }
}
