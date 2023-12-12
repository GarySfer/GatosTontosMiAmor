using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private bool dontDestroyOnLoad = true;
    public Player player;
    public GameObject PlayerGameObject => player.gameObject;
    public Inventory Inventory => player.inventory;


    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            DestroyImmediate(gameObject);
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
