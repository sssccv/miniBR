using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private SceneManager sceneManager;

    private float tiempo = 5;
    public bool J1Winner = false;
    public bool J2Winner = false;

    private void Awake()
    {
        if (instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        J2Winner = false;
        J1Winner = false;
    }

    private void Start()
    {
        sceneManager = GetComponent<SceneManager>();
    }

    void Update()
    {
        if (J1Winner||J2Winner)
        {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                if (J1Winner)
                {
                    Debug.Log("Jugador 1 Gana");
                    sceneManager.LoadScene("J1Win");
                }
                else if (J2Winner)
                {

                    Debug.Log("Jugador 2 Gana");
                    sceneManager.LoadScene("J2Win");
                }
                else
                {
                    Debug.Log("Error");
                }

                
            }
        }
    }
}
