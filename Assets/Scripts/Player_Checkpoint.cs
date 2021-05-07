using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Checkpoint : MonoBehaviour
{
    private Master_Checkpoint cm;

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<Master_Checkpoint>();
        transform.position = cm.lastCheckPointPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
