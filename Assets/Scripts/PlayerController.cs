using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidBody;

    // setando a forca do pulo
    public float JumpForce = 1.0f;
    // setando o tanto que demora para o cooldown voltar a 0;
    public float JumpCooldownInterval = 0.6f;
    private float jumpCooldown = 0f;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isgameActive = GameManager.Instance.IsGameActive();

        jumpCooldown -= Time.deltaTime;
        canJump = jumpCooldown <= 0 && isgameActive;

        // Jump!
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }
        thisRigidBody.useGravity = isgameActive;
    }
    private void OnCollisionEnter(Collision other)
    {
        GameManager.Instance.endGame();
        Debug.Log("Game Over, your score was " + GameManager.Instance.score);


    }
    private void OnTriggerEnter(Collider other)
    {
        bool isSensor = other.gameObject.CompareTag("scoreSensor");
        if (isSensor)
        {
            // aumenta pontuacao
            GameManager.Instance.score++;
            Debug.Log("Pontuacao: " + GameManager.Instance.score);
        }
    }
    private void Jump()
    {
        // resetar o cooldown
        jumpCooldown = JumpCooldownInterval;
        // aplicar forca
        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
    }
}
