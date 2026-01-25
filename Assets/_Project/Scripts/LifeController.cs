using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _maxHp = 100;

    private void Awake()
    {
        _hp = _maxHp;
    }
    public void SetHp(int hp)
    {
        _hp = Mathf.Clamp(hp, 0, _maxHp);
        if (_hp == 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage) => SetHp(_hp -  damage);
}
