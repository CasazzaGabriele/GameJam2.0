using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //###########################################################################

    #region Var

    private Rigidbody rb;

    private Vector2 input;
    private Vector2 turnInp;

    private Vector3 turn;
    private Vector3 direction;

    private float rotationSpeed = 180f;

    private float speed;

    private bool isGraunded;

    #endregion Var

    //###########################################################################

    #region ScoreSystemVar

    //###############################################
    //       Variabili per lo score System.
    //###############################################

    [HideInInspector] public float levelNois;

    [HideInInspector] public float timer = 60;
    [HideInInspector] public float seconds;
    [HideInInspector] public float score;

    [HideInInspector] public bool gameOver;
    [HideInInspector] public bool isWinner;

    #endregion ScoreSystemVar

    //###########################################################################

    //---------------------------------- START ------------------------------------------
    private void Start()
    {
        //----------------------- RESET DELLE VARIABILI ----------------------------------

        levelNois = 0f;
        seconds = 0f;
<<<<<<< Updated upstream
        speed = 40f;
=======
        speed = 60f;
>>>>>>> Stashed changes
        isWinner = false;
        gameOver = false;

        rb = GetComponent<Rigidbody>();

        rb.transform.position = new(rb.transform.position.x, 0, rb.transform.position.z);
    }

    //---------------------------------- UPDATE ------------------------------------------
    private void Update()
    {
        //###########################################################################

        #region GameOverCondition

        //--------------------------- Game Over Condition ----------------------------------------

        if (isWinner == true)
        {
            print("hai vinto");
        }

        if (timer == 0f)
        {
            gameOver = true;
        }
        else if (levelNois == 100f)
        {
            gameOver = true;
        }
        else if (levelNois == 100f && timer == 0f)
        {
            gameOver = true;
        }

        #endregion GameOverCondition

        //###########################################################################

        #region Timer

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameOver = true;
        }

        #endregion Timer

        //###########################################################################

        // Raycast nel caso dell implmentazione del salto
        isGraunded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        //rb.transform.Translate(direction * -1 * speed * Time.deltaTime, Space.Self);
        rb.velocity = (direction * -1 * speed * Time.deltaTime);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction * -1, Vector3.up);

            rb.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    //###########################################################################

    #region PlayerInputs

    // basic move function
    public void MovePlayer(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new(input.x, 0f, input.y);
        print(direction);
    }

    // Jump function
    public void Jump()
    {
        if (isGraunded)
        {
            rb.AddForce((Vector3.up * 3f) / 2f, ForceMode.Impulse);
            rb.velocity = -direction;
        }
    }

    #endregion PlayerInputs

    //###########################################################################

    #region CustomFunction

    // per gestire le interazioni con i prefab ed il level Nois
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prefab"))
        {
            print("Collisione Con Player");
            levelNois += 10f;
            //print(levelNois);
        }
    }

    // Calcolo dello score
    public void Score()
    {
        score = timer * levelNois;
    }

    // setta la variabile is winner a true ad una detterminata condizione
    public void SetisWinner(bool myBool)
    {
        isWinner = myBool;
    }

    #endregion CustomFunction

    //###########################################################################
}