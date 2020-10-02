using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanelsController : MonoBehaviour
{
    public MovePanel[] Panels;

    private void Start()
    {
        //Кешируем все панели
        Panels = GetComponentsInChildren<MovePanel>();
    }


    public void MoveAt(int indexPanel)
    {
        //Включаем панель по её индексу
        Panels[indexPanel].show = true;
    }
}
