using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private UnityEvent _onStartGame;
    void Start()
    {
        _onStartGame.Invoke();

        int selected = PlayerPrefs.GetInt("SelectedCharacter", 0);

        for (int i = 0; i < _characters.Length; i++)
        {
            _characters[i].SetActive(i == selected);
        }

        CameraOrbit cam = FindObjectOfType<CameraOrbit>();
        cam.SetTarget(_characters[selected].transform.Find("OrbitCamera"));

        Turret[] turrets = FindObjectsOfType<Turret>();
        foreach (var turret in turrets)
        {
            turret.SetTarget(_characters[selected].transform);
        }
    }
}
