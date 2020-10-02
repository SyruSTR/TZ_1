using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour
{
    [SerializeField] private float lerpSpeed = 10f;
    [SerializeField] private float pointY = -0.6f;
    public bool show;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (show)
            //Останавливаем панель, чтобы не уехала слишком далеко
            if (transform.position.x < pointY)
                MovePanelToUp();
    }
    private void MovePanelToUp()
    {        
        //Используем метод Lerp для плавности появления панели
        transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, pointY, lerpSpeed * Time.deltaTime));
    }
}
