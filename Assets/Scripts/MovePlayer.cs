using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    private Vector3 startTouchPos;
    private CharacterController playerController;
    [SerializeField] private float _playerSpeed;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log($"Start Player Move:");
            //Запоминаем место, где произошло первое нажатие
            startTouchPos = Input.mousePosition;
            //Debug.Log($"Start Poition: {startTouchPos}");
        }
        else if (Input.GetMouseButton(0))
        {
            //Debug.Log($"Begin Player Move:");
            //Находим текущее направление курсора\пальца игрока
            Vector2 direction = Input.mousePosition - startTouchPos;
            //Нормализируем вектор для более удобной работы с ним
            direction.Normalize();
            //Debug.Log($"Normalized direction: {direction}");
            //Debug.Log($"Direction: {direction}");
            //Заставляем персонажа идти в указаном направлении, не забывая про скорость
            playerController.Move(
                new Vector3(direction.x, 0f, direction.y)
                * _playerSpeed
                * Time.deltaTime
                );
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($"End Player Move:");
        }
    }
    // Update is called once per frame
    
}
