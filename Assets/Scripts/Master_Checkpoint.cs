using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Checkpoint : MonoBehaviour
{
    private static Master_Checkpoint instance;
    public Vector2 lastCheckPointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
