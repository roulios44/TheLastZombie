using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject Zombie;
    private Zombie character;
    private int MaxHP;
    private int HP;
    [SerializeField]
    private RectTransform _topBar;
    [SerializeField]
    private RectTransform _bottomBar;
    private float _fullWidth;
    private Coroutine _adjustBarWidthCoroutine;
    private float TargetWidth => HP * _fullWidth / MaxHP;

    private void Start() {
        _fullWidth = _topBar.rect.width;
        this.character = Zombie.GetComponent<Zombie>();
        this.MaxHP = this.character.maxHP;
    }
    public void Change(int amount) {
        HP = Mathf.Clamp(HP + amount, 0, MaxHP);
        if (_adjustBarWidthCoroutine != null) {
            StopCoroutine(_adjustBarWidthCoroutine);
        }
        _adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }

    private void Update() {
        this.HP = this.character.currentHP;
        Change(this.character.currentHP/this.character.maxHP);
        // if (Input.GetMouseButtonDown(0)) {
        //     Change(20);
        // }
        // if (Input.GetMouseButtonDown(1)) {
        //     Change(-20);
        // }
    }

    private IEnumerator AdjustBarWidth(int amount) {
        var suddenChangeBar = amount >= 0 ? _bottomBar : _topBar;
        var slowChangeBar = amount >= 0 ? _topBar : _bottomBar;
        suddenChangeBar.SetWidth(TargetWidth);
        while (Mathf.Abs(suddenChangeBar.rect.width - slowChangeBar.rect.width)>1f) {
            slowChangeBar.SetWidth(Mathf.Lerp(slowChangeBar.rect.width, TargetWidth, Time.deltaTime * 3f));
            yield return null;
        }
        slowChangeBar.SetWidth(TargetWidth);
    }
}