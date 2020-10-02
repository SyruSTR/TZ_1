using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListenersOnNextLelevButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Переключаем сцену на следующую, при нажатии на кнопку
        GetComponent<Button>().onClick.AddListener(FindObjectOfType<SceneController>().LoadNextLevel);
    }
}
