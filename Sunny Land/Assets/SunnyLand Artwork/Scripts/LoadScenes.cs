using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] private String SceneName;

    public void Load()
    {
        // Sử dụng load scene của SceneManager -> truyền vào một chuỗi string là tên scene mình muốn load
        // ngoài ra có thể truyền biến int nhưng truyền bằng một chuỗi string tên scene để không phải nhớ order của scene
        SceneManager.LoadScene(SceneName);
    }
}
