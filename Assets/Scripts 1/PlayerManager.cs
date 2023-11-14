using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //###########################################################################

    #region Var

    private Rigidbody rb;

    private Vector2 input;
    private Vector3 direction;

    [HideInInspector] public float speed;

    private bool isGraunded;

    #endregion Var

    //###########################################################################

    #region ScoreSystemVar

    //###############################################
    //       Variabili per lo score System.
    //###############################################

    [HideInInspector] public int levelNois;

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

        levelNois = 100;
        seconds = 0f;
        speed = 70f;
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
        else if (levelNois == 0)
        {
            gameOver = true;
        }
        else if (levelNois == 0 && timer == 0f)
        {
            gameOver = true;
        }

        #endregion GameOverCondition

        //###########################################################################

        #region Timer

        //---------------------------------timer---------------------------------------
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
    }

    //###########################################################################

    #region PlayerINputs

    //###########################################################################
    //                            Player Inputs
    //###########################################################################

    public void MovePlayer(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new(input.x, 0f, input.y);
        print(direction);
    }

    public void Jump()
    {
        if (isGraunded)
        {
            rb.AddForce((Vector3.up * 3f) / 2f, ForceMode.Impulse);
            rb.velocity = -direction;
        }
    }

    public void SetSpeed(float x)
    {
        speed = x;
    }

    #endregion PlayerINputs

    //###########################################################################

    #region CustomFunction

    //###########################################################################
    //                                     score Function
    //###########################################################################
    public void Score()
    {
        score = timer * levelNois;
    }

    public void SetisWinner(bool myBool)
    {
        isWinner = myBool;
    }

    #endregion CustomFunction

    //###########################################################################
}