using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Return : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("WorldMap");
    }
}