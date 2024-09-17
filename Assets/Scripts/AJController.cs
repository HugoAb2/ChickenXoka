using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isRetreatingHash;
    int isRunningBackHash;

    public float turnSpeed = 200f; // Velocidade de rotação
    public float moveSpeed = 2f;   // Velocidade de movimento
    public float runSpeed = 4f;    // Velocidade de corrida

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isRetreatingHash = Animator.StringToHash("isRetreating");
        isRunningBackHash = Animator.StringToHash("isRunningBack");
    }

    void Update()
    {
        // Entrada do jogador
        bool forwardPress = Input.GetKey("w");
        bool backPress = Input.GetKey("s");
        bool leftPress = Input.GetKey("a");
        bool rightPress = Input.GetKey("d");
        bool runPress = Input.GetKey("left shift") || Input.GetKey("right shift");

        // Atualizar estado de andar (frente e lados)
        bool isWalking = forwardPress;
        bool isWalkingBack = backPress;

        animator.SetBool(isWalkingHash, isWalking);

        animator.SetBool(isRunningHash, forwardPress && runPress);

        animator.SetBool(isRetreatingHash, isWalkingBack);

        animator.SetBool(isRunningBackHash, backPress && runPress);

        if (leftPress)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (rightPress)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Movimento para frente
        if (forwardPress)
        {
            float speed = runPress ? runSpeed : moveSpeed; // Corre se estiver pressionando o shift
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // Movimento para trás
        else if (backPress)
        {
            float speed = runPress ? runSpeed : moveSpeed; // Corre para trás se estiver pressionando o shift
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
