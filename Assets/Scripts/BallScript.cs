using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

    private readonly Vector2 mXAxis = new Vector2(1, 0);
    private readonly Vector2 mYAxis = new Vector2(0, 1);

    // The angle range for detecting swipe
    private const float mAngleRange = 30;

    // To recognize as swipe user should at lease swipe for this many pixels
    private const float mMinSwipeDist = 2.5f;

    // To recognize as a swipe the velocity of the swipe
    // should be at least mMinVelocity
    // Reduce or increase to control the swipe speed
    private const float mMinVelocity = 2000.0f;

    private Vector2 mStartPosition;
    private float mSwipeStartTime;

    private int mMessageIndex = 0;

    public bool swipeUp = false;
    public bool swipeDown = false;
    public bool swipeRight = false;
    public bool swipeLeft = false;

    public bool llegoArriba = false;
    public bool llegoAbajo = true;
    public bool llegoDerecha = false;
    public bool llegoIzquierda = false;

    public bool upBut = false;
    public bool downBut = false;
    public bool leftBut = false;
    public bool rightBut = false;

    public bool isUp = false;
    public bool isDown = true;
    public bool isLeft = false;
    public bool isRight = false;

    public bool lastUp = false;
    public bool lastDown = false;
    public bool lastLeft = false;
    public bool lastRight = false;

    public int count;
    public Text countText;

    private float northDistance = 2.143f;
    private float eastDistance = 1.88f;

    private float speed = 4f;


    // Use this for initialization
    void Start () {
        count = 0;
        countText.text = "SCORE: " + count.ToString() + "\n" + "Highest Score: " + PlayerPrefs.GetInt("HighestScore");
	}

    // Update is called once per frame
    void Update()
    {

        ///////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////Prueba Para Swipe////////////////////////////////
        // Mouse button down, possible chance for a swipe
        if (Input.GetMouseButtonDown(0))
        {
            // Record start time and position
            mStartPosition = new Vector2(Input.mousePosition.x,
                                         Input.mousePosition.y);
            mSwipeStartTime = Time.time;
        }

        // Mouse button up, possible chance for a swipe
        if (Input.GetMouseButtonUp(0))
        {
            float deltaTime = Time.time - mSwipeStartTime;

            Vector2 endPosition = new Vector2(Input.mousePosition.x,
                                               Input.mousePosition.y);
            Vector2 swipeVector = endPosition - mStartPosition;

            float velocity = swipeVector.magnitude / deltaTime;

            if (velocity > mMinVelocity &&
                swipeVector.magnitude > mMinSwipeDist)
            {
                // if the swipe has enough velocity and enough distance

                swipeVector.Normalize();

                float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
                angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

                // Detect left and right swipe
                if (angleOfSwipe < mAngleRange)
                {
                    OnSwipeRight();
                }
                else if ((180.0f - angleOfSwipe) < mAngleRange)
                {
                    OnSwipeLeft();
                }
                else
                {
                    // Detect top and bottom swipe
                    angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
                    angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
                    if (angleOfSwipe < mAngleRange)
                    {
                        OnSwipeTop();
                    }
                    else if ((180.0f - angleOfSwipe) < mAngleRange)
                    {
                        OnSwipeBottom();
                    }
                    else
                    {
                        mMessageIndex = 0;
                    }
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////



        if ((Input.GetKey("up") || swipeUp) && !downBut && !leftBut && !rightBut && !llegoArriba)
        {
            upBut = true;
            print("Up");
        }
        else if ((Input.GetKey("down") || swipeDown) && !upBut && !leftBut && !rightBut && !llegoAbajo)
        {
            downBut = true;
            print("Down");
        }
        else if ((Input.GetKey("left") || swipeLeft) && !downBut && !upBut && !rightBut && !llegoIzquierda)
        {
            leftBut = true;
            print("Left");
        }
        else if ((Input.GetKey("right") || swipeRight) && !downBut && !leftBut && !upBut && !llegoDerecha)
        {
            rightBut = true;
            print("Right");
        }


        if (upBut)
        {
            downBut = false;
            leftBut = false;
            rightBut = false;
            llegoAbajo = false;
            llegoDerecha = false;
            llegoIzquierda = false;

            if (!llegoArriba)
            {
                //the speed, in units per second, we want to move towards the target
                //float speed = 9;
                //move towards the center of the world (or where ever you like)
                Vector3 targetPosition = new Vector3(0, northDistance, 0);

                Vector3 currentPosition = this.transform.position;

                //first, check to see if we're close enough to the target
                if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                {
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    this.transform.Translate(
                        (directionOfTravel.x * speed * Time.deltaTime),
                        (directionOfTravel.y * speed * Time.deltaTime),
                        (directionOfTravel.z * speed * Time.deltaTime),
                        Space.World);
                }
                else
                {
                    llegoArriba = true;
                    upBut = false;
                    swipeUp = false;
                    count++;
                    countText.text = "SCORE: " + count.ToString() + "\n" + "Highest Score: " + PlayerPrefs.GetInt("HighestScore");

                    if (isDown)
                    {
                        isUp = true;
                        isDown = false;
                        isRight = false;
                        isLeft = false;

                        lastDown = true;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = false;
                    }

                    if (isLeft)
                    {
                        isUp = true;
                        isDown = false;
                        isRight = false;
                        isLeft = false;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = true;
                        lastRight = false;
                    }

                    if (isRight)
                    {
                        isUp = true;
                        isDown = false;
                        isRight = false;
                        isLeft = false;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = true;
                    }

                }

            }
        }//Fin del upBut

        if (downBut)
        {
            upBut = false;
            leftBut = false;
            rightBut = false;
            llegoArriba = false;
            llegoDerecha = false;
            llegoIzquierda = false;

            if (!llegoAbajo)
            {
                //the speed, in units per second, we want to move towards the target
                //float speed = 9;
                //move towards the center of the world (or where ever you like)
                Vector3 targetPosition = new Vector3(0, -(northDistance), 0);

                Vector3 currentPosition = this.transform.position;
                //first, check to see if we're close enough to the target

                if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                {
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    this.transform.Translate(
                        (directionOfTravel.x * speed * Time.deltaTime),
                        (directionOfTravel.y * speed * Time.deltaTime),
                        (directionOfTravel.z * speed * Time.deltaTime),
                        Space.World);

                }
                else
                {
                    llegoAbajo = true;
                    downBut = false;
                    swipeDown = false;
                    count++;
                    countText.text = "SCORE: " + count.ToString() + "\n" + "Highest Score: " + PlayerPrefs.GetInt("HighestScore");

                    if (isRight)
                    {
                        isUp = false;
                        isDown = true;
                        isRight = false;
                        isLeft = false;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = true;
                    }

                    if (isLeft)
                    {
                        isUp = false;
                        isDown = true;
                        isRight = false;
                        isLeft = false;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = true;
                        lastRight = false;
                    }

                    if (isUp)
                    {
                        isUp = false;
                        isDown = true;
                        isRight = false;
                        isLeft = false;

                        lastDown = false;
                        lastUp = true;
                        lastLeft = false;
                        lastRight = false;
                    }
                }


            }
        }//fin de downBut

        if (rightBut)
        {
            downBut = false;
            leftBut = false;
            upBut = false;
            llegoAbajo = false;
            llegoArriba = false;
            llegoIzquierda = false;

            if (!llegoDerecha)
            {
                //the speed, in units per second, we want to move towards the target
                //float speed = 9;
                //move towards the center of the world (or where ever you like)
                Vector3 targetPosition = new Vector3(eastDistance, 0, 0);

                Vector3 currentPosition = this.transform.position;
                //first, check to see if we're close enough to the target

                if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                {
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    this.transform.Translate(
                        (directionOfTravel.x * speed * Time.deltaTime),
                        (directionOfTravel.y * speed * Time.deltaTime),
                        (directionOfTravel.z * speed * Time.deltaTime),
                        Space.World);
                }
                else
                {
                    llegoDerecha = true;
                    rightBut = false;
                    swipeRight = false;
                    count++;
                    countText.text = "SCORE: " + count.ToString() + "\n" + "Highest Score: " + PlayerPrefs.GetInt("HighestScore");

                    if (isUp)
                    {
                        isUp = false;
                        isDown = true;
                        isRight = true;
                        isLeft = false;

                        lastDown = false;
                        lastUp = true;
                        lastLeft = false;
                        lastRight = false;
                    }

                    if (isDown)
                    {
                        isUp = false;
                        isDown = false;
                        isRight = true;
                        isLeft = false;

                        lastDown = true;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = false;

                    }

                    if (isLeft)
                    {
                        isUp = false;
                        isDown = false;
                        isRight = true;
                        isLeft = false;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = true;
                        lastRight = false;

                    }
                }
            }
        }//fin de rightBut


        if (leftBut)
        {
            downBut = false;
            upBut = false;
            rightBut = false;

            llegoAbajo = false;
            llegoDerecha = false;
            llegoArriba = false;

            if (!llegoIzquierda)
            {
                //the speed, in units per second, we want to move towards the target
                //float speed = 9;
                //move towards the center of the world (or where ever you like)
                Vector3 targetPosition = new Vector3(-(eastDistance), 0, 0);

                Vector3 currentPosition = this.transform.position;
                //first, check to see if we're close enough to the target

                if (Vector3.Distance(currentPosition, targetPosition) > .1f)
                {
                    Vector3 directionOfTravel = targetPosition - currentPosition;
                    //now normalize the direction, since we only want the direction information
                    directionOfTravel.Normalize();
                    //scale the movement on each axis by the directionOfTravel vector components

                    this.transform.Translate(
                        (directionOfTravel.x * speed * Time.deltaTime),
                        (directionOfTravel.y * speed * Time.deltaTime),
                        (directionOfTravel.z * speed * Time.deltaTime),
                        Space.World);
                }
                else
                {
                    llegoIzquierda = true;
                    leftBut = false;
                    swipeLeft = false;
                    count++;
                    countText.text = "SCORE: " + count.ToString() + "\n" + "Highest Score: " + PlayerPrefs.GetInt("HighestScore");

                    if (isRight)
                    {
                        isUp = false;
                        isDown = false;
                        isRight = false;
                        isLeft = true;

                        lastDown = false;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = true;

                    }

                    if (isDown)
                    {
                        isUp = false;
                        isDown = false;
                        isRight = false;
                        isLeft = true;

                        lastDown = true;
                        lastUp = false;
                        lastLeft = false;
                        lastRight = false;

                    }

                    if (isUp)
                    {
                        isUp = false;
                        isDown = false;
                        isRight = false;
                        isLeft = true;

                        lastDown = false;
                        lastUp = true;
                        lastLeft = false;
                        lastRight = false;

                    }
                }
            }

        }//fin de leftBut
    }

    private void OnSwipeLeft()
    {
        if (!swipeRight && !swipeUp && !swipeDown)
        {
            swipeLeft = true;
        }
    }

    private void OnSwipeRight()
    {
        if (!swipeLeft && !swipeUp && !swipeDown)
        {
            swipeRight = true;
        }
    }

    private void OnSwipeTop()
    {
        if (!swipeRight && !swipeLeft && !swipeDown)
        {
            swipeUp = true;
        }
    }

    private void OnSwipeBottom()
    {
        if (!swipeRight && !swipeUp && !swipeLeft)
        {
            swipeDown = true;
        }
    }

}   
