﻿using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    } 

    void OnTriggerEnter2D(Collider2D collider)
    {
        levelManager.LoadLevel("Lose");
    }
}
