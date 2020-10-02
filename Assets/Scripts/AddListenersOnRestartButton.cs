using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListenersOnRestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Перезапускаем сцену при нажатии на кнопку
        GetComponent<Button>().onClick.AddListener(FindObjectOfType<SceneController>().RestartScene);
    }
}
