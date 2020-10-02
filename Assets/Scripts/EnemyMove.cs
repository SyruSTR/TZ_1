using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] private Transform[] pointsToMove;
    [SerializeField] private float awaitFromChangePointToMove;
    private bool isAwating = false;
    private int selectedPoint = 0;
    private NavMeshAgent enemyContoller;



    private void Awake()
    {
        enemyContoller = GetComponent<NavMeshAgent>();
        
    }
    // Start is called before the first frame update
    
    void Start()
    {
        //Проверяем, есть ли точки, по которым ходит противник
        if (pointsToMove.Length <= 1)
        {
            Debug.LogError("No points To move or enemy have ONE point");
        }
        //Включаем возможность двигаться
        enemyContoller.isStopped = false;
        //if (pointsToMove.Length > 0)
        //    StartCoroutine(WaitingBeforeMoving());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, pointsToMove[selectedPoint].position));
        //Если нет точек для пережвижени, нет смысла и идти
        if (pointsToMove.Length > 0)
        {
            //Проверяем, дошёл ли противник до точки и идёт ли он в данный момент
            if (Vector3.Distance(transform.position, pointsToMove[selectedPoint].position) < 0.3f && !enemyContoller.isStopped)
            {
                //Если это так, запускаем подпрограмму
                StartCoroutine(WaitingBeforeMoving());
            }
        }
    }
    IEnumerator WaitingBeforeMoving()
    {
        //Останавливаем противника
        enemyContoller.isStopped = true;
        
        yield return new WaitForSeconds(awaitFromChangePointToMove);

        //Проверяем, на каком индеске массива точек мы находимся
        if (selectedPoint < pointsToMove.Length - 1)
            selectedPoint++;
        //Если мы на последнем элементе, переходим на первый
        else if (selectedPoint == pointsToMove.Length - 1)
            selectedPoint = 0;
        //Указываем следущую цель для противника
        enemyContoller.SetDestination(pointsToMove[selectedPoint].position);
        enemyContoller.isStopped = false;
    }
}
