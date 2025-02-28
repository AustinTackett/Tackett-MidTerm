using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButtonBehaviour : MonoBehaviour
{
    public void goToGame() 
    {
        SceneManager.LoadScene("gameplay");
    }
}
