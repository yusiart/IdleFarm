using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _cointCount;
    [SerializeField] private AnimationCoin _coinForAnimation;

    private Barn _barn;
    private int _count;
    private Canvas _canvas;
    private Camera _camera;
    private Transform _target;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
        _barn = FindObjectOfType<Barn>();
        _camera = FindObjectOfType<Camera>();
        _cointCount.text = _count.ToString();
        _target = _cointCount.GetComponentInChildren<Image>().transform;
    }

    private void OnEnable()
    {
        _barn.OnCornAdded += OnCountChanged;
    }

    private void OnDisable()
    {
        _barn.OnCornAdded -= OnCountChanged;
    }
    
    private void OnCountChanged(int price)
    {
        _count += price;
        _cointCount.text = _count.ToString();
        PlayAnimationCoin();
    }

    private void PlayAnimationCoin()
    {
        //Transform target = _barn.transform;
        Vector3 rayOrigin = _camera.WorldToScreenPoint(_barn.transform.position);
        Instantiate(_coinForAnimation, rayOrigin, Quaternion.identity, _canvas.transform).Move(_target.transform);
    }
}
