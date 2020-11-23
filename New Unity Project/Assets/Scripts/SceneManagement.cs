using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneTransition()
    {
        SceneManager.LoadScene("Scene1A");
        GameObject.Find("Player").GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
        GameObject.Find("Player").transform.localScale = new Vector3(0.2f,0.2f,0.2f);
    }
}

