using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Debug.Log("Level Complete");
            //Не даём игроку возможность передвигать персонажа
            GetComponent<CharacterController>().enabled = false;
            //Включаем WinPanel
            FindObjectOfType<MovePanelsController>().MoveAt(0);
        }
    }
}
