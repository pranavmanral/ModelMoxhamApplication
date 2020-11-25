using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneTransition()
    {
        SceneManager.LoadScene("Scene1");
        
    }
}
