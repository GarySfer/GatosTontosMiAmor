using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private bool dontDestroyOnLoad = true;
    public Player player;
    public Inventory inventory => player.inventory;


    protected virtual void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }

        Instance = this;

        if (dontDestroyOnLoad) DontDestroyOnLoad(gameObject);


        SetupOnAwake();
    }

    protected virtual void SetupOnAwake()
    {
        
    }
}
