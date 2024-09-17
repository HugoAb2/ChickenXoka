using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    public float turnSpeed = 200f; // Velocidade de rotação
    public float moveSpeed = 2f;   // Velocidade de movimento

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        // Entrada do jogador
        bool forwardPress = Input.GetKey("w");
        bool backPress = Input.GetKey("s");
        bool leftPress = Input.GetKey("a");
        bool rightPress = Input.GetKey("d");
        bool runPress = Input.GetKey("left shift");

        // Atualizar estado de andar (frente, trás)
        bool isWalking = forwardPress || backPress || leftPress || rightPress;
        animator.SetBool(isWalkingHash, isWalking);

        // Atualizar estado de correr (somente para frente)
        animator.SetBool(isRunningHash, forwardPress && runPress);

        // Rotação para esquerda e direita
        if (leftPress)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (rightPress)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Movimento para frente e para trás
        if (forwardPress)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (backPress)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
}
