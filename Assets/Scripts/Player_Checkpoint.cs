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
            playerDied();
        }
        if (GetComponent<Animator>().GetBool("IsDead") == true)
        {
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        playerDied();
    }
        public void playerDied()
    {
        Debug.Log("DEAD\n");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
