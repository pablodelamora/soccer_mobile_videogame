using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenterPlayer1Script : MonoBehaviour
{

    bool up;
    bool down;
    bool left;
    bool right;

    bool randomNumber;
    bool ayudaRandomNumber;
    bool primeraEsLibre;

    public BallScript movimientos;

    Transform JCentro2;
    Transform Ball;

    int numberMov;

    float MoveSpeed = 1.14f;
    float MoveSpeedFast = 4.5f;
    float MoveSpeedSlow = 1.15f;

    float x1 = -.9f;
    float x2 = 0;
    float x3 = .9f;

    float y1 = -.9f;
    float y2 = 0;
    float y3 = 1.2f;

    //[SerializeField] private GameObject pausePanel;



    // Use this for initialization
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball").transform;
        JCentro2 = GameObject.FindGameObjectWithTag("JCentro2").transform; // Este se va en el original
        randomNumber = true;
        primeraEsLibre = false;
        ayudaRandomNumber = true;
        //pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Las siguientes 4 lineas es para poder tener a los jugadores siempre viendo hacia el balon
        Vector3 diff = Ball.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (movimientos.upBut || movimientos.downBut || movimientos.leftBut || movimientos.rightBut || Input.GetKey("up"))
        {
            primeraEsLibre = true;
        }

        if (primeraEsLibre)
        {
            if (Vector3.Distance(transform.position, Ball.position) < Vector3.Distance(JCentro2.position, Ball.position))
            {
                transform.position += transform.up * MoveSpeed * Time.deltaTime;
            }
            else
            {
                if (randomNumber)
                {
                    randomNumber = false;
                    numberMov = Random.Range(1, 10);
                }

                if (numberMov == 1)
                {
                    Vector3 targetPosition = new Vector3(x1, y1, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }

                if (numberMov == 2)
                {
                    Vector3 targetPosition = new Vector3(x1, y2, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 3)
                {
                    Vector3 targetPosition = new Vector3(x1, y3, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 4)
                {
                    Vector3 targetPosition = new Vector3(x2, y1, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 5)
                {
                    Vector3 targetPosition = new Vector3(x2, y2, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 6)
                {
                    Vector3 targetPosition = new Vector3(x2, y3, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 7)
                {
                    Vector3 targetPosition = new Vector3(x3, y1, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 8)
                {
                    Vector3 targetPosition = new Vector3(x3, y2, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }
                if (numberMov == 9)
                {
                    Vector3 targetPosition = new Vector3(x3, y3, 0);
                    Vector3 currentPosition = this.transform.position;
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                    {
                        this.transform.Translate(
                            (directionOfTravel.x * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.y * MoveSpeedSlow * Time.deltaTime),
                            (directionOfTravel.z * MoveSpeedSlow * Time.deltaTime),
                            Space.World);
                    }
                }

                if ((movimientos.llegoAbajo || movimientos.llegoArriba || movimientos.llegoDerecha || movimientos.llegoIzquierda)
                    && ayudaRandomNumber)
                {
                    randomNumber = true;
                    ayudaRandomNumber = false;
                }

                if (movimientos.upBut || movimientos.downBut || movimientos.leftBut || movimientos.rightBut)
                {
                    ayudaRandomNumber = true;
                }

            }
        }

    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "soccerBall")
        {
            if (movimientos.count > PlayerPrefs.GetInt("HighestScore"))
            {
                PlayerPrefs.SetInt("HighestScore", movimientos.count);
            }
            print("Perdiste");
            for (int i=0; i < 99999999; i++)
            {
                continue;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
