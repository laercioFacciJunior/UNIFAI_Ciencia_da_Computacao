using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
     public int life; //variável vida
     public Transform skin; //acesso ao objeto skin

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //verificando se a vida está em zero ou abaixo de zero
        if (life <= 0)
        {
            //setando animação de morte
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }
}
