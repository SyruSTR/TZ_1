using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sScan : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private int raysCount;
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject cubeRayPrefab;
    private GameObject[] cubesRays;
    void Start()
    {
        cubesRays = new GameObject[raysCount];
    }

    // Update is called once per frame
    void Update()
    {
        //Если во время запущеной игры изменилось кол-во лучей
        //Уничтожаем все созданные префабы
        //И очищаем старый массив и создаём новый
        if (cubesRays.Length != raysCount)
        {
            foreach (var cubeRay in cubesRays)
            {
                Destroy(cubeRay);
            }
            cubesRays = new GameObject[0];
            cubesRays = new GameObject[raysCount];
        }
        //Находим точку начала нужной нам дуги от нуля
        float startAngle = angle * (raysCount - 1) / 2;
        //Debug.Log(startAngle);

        //Для вычеслиний использовал единичную окружность
        //Из основ тригонометрии
        for (int i = 0; i < raysCount; i++)
        {
            RaycastHit hit;
            //От начала полученной выше дуги в градусасы
            //отнимаем угол\углы до следующей точки и переводим в радианы
            float currentAngle = (startAngle - angle * i) * Mathf.Deg2Rad;
            //Находим точку в пространсте относительно игрока, в направлении луча
            //Использая формулы тригонометрии
            //y = sin(alpha)
            //x = cos(alpha)
            //Но в нашем случаем немного меняем оси для корректной работы
            Vector3 direction = transform.TransformDirection(
                new Vector3(
                    Mathf.Sin(currentAngle),
                    0f,
                    Mathf.Cos(currentAngle)));
            //Создаём пустой объект для будущего кеширования
            GameObject cubeRay = null;
            //Если массив пустой создаём новый объект
            if (cubesRays[i] == null)
            {
                cubeRay = Instantiate(
                    cubeRayPrefab,
                    transform.position,
                    Quaternion.Euler(
                        0f,
                        //Указываем на сколько необходимо повернуть луч,
                        //не забывая сделать поправку, на положение игрока до создания префаба
                        (startAngle - angle * i) + transform.rotation.eulerAngles.y,
                        0f),
                    transform);
                //кешируем полученный ранее префаб
                cubesRays[i] = cubeRay;
            }
            else
                //Если массив не пустой, то кешируем существующий префаб
                cubeRay = cubesRays[i];
            //Изменяем размер луча, под длину луча
            cubeRay.transform.localScale = new Vector3(cubeRay.transform.localScale.x, cubeRay.transform.localScale.y, rayDistance);
            if (Physics.Raycast(
                transform.position,
                direction,
                out hit,
                rayDistance))
            {
                
                //Если луч задел коллайдер, изменяем длину "физического" луча до точки попадания
                cubeRay.transform.localScale = new Vector3(cubeRay.transform.localScale.x, cubeRay.transform.localScale.y, hit.distance);

                
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Hit Player");
                    
                    //Останавливаем движение игроку, раз попал в поле зрения противника
                    hit.collider.GetComponent<CharacterController>().enabled = false;
                    //Выводим панель с ГеймОвер-ом
                    FindObjectOfType<MovePanelsController>().MoveAt(1);
                }
                
                //Debug.DrawLine(transform.position, hit.point, Color.red);
            }
            //else
                //Debug.DrawRay(transform.position, direction * rayDistance, Color.green);


        }
    }
}
