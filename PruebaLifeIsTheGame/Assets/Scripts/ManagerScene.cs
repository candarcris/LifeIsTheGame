using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ManagerScene : MonoBehaviour
{
    Button select;
    void Awake()
    {
        select = GetComponent<Button>();
    }

    void Start()
    {
        select.onClick.AddListener(SceneLoad);
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(1);
    }
}
