using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.SetInt("LevelNumber", 0);
        //Оставляем объект(Данный компонент) для следующих сцен
        DontDestroyOnLoad(transform.gameObject);
        //Забираем номер сцены из памяти
        //если первый запуск приложения, то запускается сцена с кнопкой старт
        int sceneIndex = PlayerPrefs.GetInt("LevelNumber");
        Debug.Log("Save level:" + sceneIndex);
        //Для предотвращения вечной перезагрузки первой сцены)
        if (sceneIndex > 0)
            SceneManager.LoadScene(sceneIndex);
    }

    //Сохраняем текущий индекс сцены
    public void SaveSceneNumber()
    {
        PlayerPrefs.SetInt("LevelNumber", SceneManager.GetActiveScene().buildIndex);
    }
    private void OnApplicationQuit()
    {
        SaveSceneNumber();
    }
    //Перезапускаем сцену
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Загружаем след. сцену
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
