using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartLevel : MonoBehaviour
{
    private Transform startPoint;
    private bool startMove;
    CharacterController charController;
    ParticleSystem startEffect;
    // Start is called before the first frame update
    private void Awake()
    {
        startMove = false;
        charController = GetComponent<CharacterController>();
        startEffect = GetComponentInChildren<ParticleSystem>();
        charController.enabled = false;
        startPoint = FindObjectOfType<StartPoint>().transform;
        
    }
    void Start()
    {
        transform.position = new Vector3(
            startPoint.position.x,
            startPoint.position.y + 20,
            startPoint.position.z);
        StartCoroutine(ShowPlayer());
    }

    IEnumerator ShowPlayer()
    {
        //Ждём одну секунду, прежде чем появится игрок
        yield return new WaitForSeconds(1f);
        startMove = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            //Проверям, приземлился ли игрок и для плавности используем метод Lerp
            if (transform.position.y - startPoint.position.y > 0.1)
                transform.position = Vector3.Lerp(transform.position, startPoint.position, 10f * Time.deltaTime);
            else
            {
                //Включаем частицы
                startEffect.Play();
                //Даём возможность передвигать персонажа
                charController.enabled = true;
                //Уничтожаем компонет, так как он больше не нужен
                Destroy(GetComponent<PlayerStartLevel>());
            }
        }
    }
}
