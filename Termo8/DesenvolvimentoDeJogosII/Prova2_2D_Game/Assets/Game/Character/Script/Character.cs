using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public int life; //variavel vida
    public Transform skin; // acesso ao objeto skin
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }
}
