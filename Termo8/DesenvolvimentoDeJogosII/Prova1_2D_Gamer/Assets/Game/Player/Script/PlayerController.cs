using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb; //variável rigidbody
    Vector2 vel; //variável vetor de duas posições x e y
    public Transform floorCollider; //variável para acessar outro script
    public Transform skin; //variável para acesso ao animator
    public float dashTime; //variavel que controla o tempo do dash

    // Start is called before the first frame update
    void Start()
    {
        //iniciando a variável com o componente
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //captando os comandos para pular da Unity e setando a velocidade
        if (Input.GetButtonDown("Jump") && floorCollider.GetComponent<FloorCollider>(). canJump == true)
        {
            //setando quando pular para animação jump
            skin.GetComponent<Animator>().Play("Jump", -1);
            rb.velocity = Vector2.zero;
            floorCollider.GetComponent<FloorCollider>().canJump = false;
            rb.AddForce(new Vector2(0, 400));
        }

        //captando os comandos para andar (horizontalmente) da Unity e setando a velocidade
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //virando o personagem para a direção correta
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"),1,1);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }

        //verificando se a variável life (script Character), é zero ou menor
        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
        }

        //inicializando dashtime
        dashTime = dashTime + Time.deltaTime;

        //captando comando para dash, da Unity e modificando a animação
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            dashTime = 0;

            //setando animação de dash
            skin.GetComponent<Animator>().Play("Dash", -1);

            rb.velocity = Vector2.zero; //zerando a velocidade depois do dash

            rb.AddForce(new Vector2(skin.localScale.x * 500, 0)); //adicionando no player uma força
        }
    }

    // funcao update fixo
    private void FixedUpdate()
    {
        //captando comando para dash, da Unity e modificando a animação
        if (dashTime >= 0.5f)
        {
            rb.velocity = vel; //captando valor e sentando na velocidade do corpo rígido
        }
    }
}
