using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private UnityEvent<int, int> _onHPChanged;
    [SerializeField] private UnityEvent _onDefeated;

    private void Awake()
    {
        _hp = _maxHp;
    }
    public void SetHp(int hp)
    {
        _hp = Mathf.Clamp(hp, 0, _maxHp);

        _onHPChanged.Invoke(_hp, _maxHp);

        if (_hp == 0)
        {
            Destroy(gameObject);
            _onDefeated.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void TakeDamage(int damage) => SetHp(_hp - damage);
}
