using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Checks if there is an active player, will instantiate one if not present in the scene
        if (GameManager.instance == null)
        {
            GameManager.instance = Instantiate(gameManager).GetComponent<GameManager>();
        }
    }
}
