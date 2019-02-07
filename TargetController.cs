﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetController : MonoBehaviour
{

    public float cameraSpeed = 300.0f;
    public float cameraSpeed2 = 0.0f;

    private Animator animator;
    private Rigidbody2D objectiveRigidBody;
    public bool pause = false;
    private bool moving = false;
    private float cameraHorizontal;
    public Vector2 lastMovementCamera = Vector2.zero;
    private float _contador; 

    private const string movingState = "moving";

    public static bool playerCreated;

    private void Start()
    {
        objectiveRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        lastMovementCamera = new Vector2(1, 0);
        _contador = 1;
       
    }



    void Update()
    {
        cameraSpeed = 230.0f + _contador; //Crete a method to modify this depending on the level dificulty
        moving = false;

        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            moving = true;
            cameraHorizontal = Random.Range(0.9f, 1.3f);
            cameraSpeed2 = cameraSpeed * cameraHorizontal;
            lastMovementCamera = new Vector2(1, 0);

            objectiveRigidBody.velocity = lastMovementCamera.normalized * cameraSpeed2 * Time.deltaTime;
        }


        if (!moving)
        {
            objectiveRigidBody.velocity = Vector2.zero;
        }
        //animator.SetBool(movingState, moving);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            _contador += 1;
        }
    }
}