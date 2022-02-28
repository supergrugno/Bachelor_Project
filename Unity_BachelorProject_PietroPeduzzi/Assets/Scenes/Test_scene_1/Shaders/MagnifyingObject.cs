using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingObject : MonoBehaviour
{
    Renderer _renderer;
    Camera _cam;

    public GameObject bubbleHead;

    [SerializeField] AnimationCurve _DisplacementCurveEXIT;
    [SerializeField] AnimationCurve _DisplacementCurveENTER;
    [SerializeField] float _DisplacementMagnitude;
    [SerializeField] float _LerpSpeed;
    [SerializeField] float _DissolveSpeed;
    private bool _shieldIsOn;

    private Coroutine _dissolveCoroutine;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _cam = Camera.main;
    }

    private void Update()
    {
        Zoom();

    }



    private void Zoom()
    {
        Vector3 screenPoint = _cam.WorldToScreenPoint(transform.position);
        screenPoint.x = screenPoint.x / Screen.width;
        screenPoint.y = screenPoint.y / Screen.height;
        _renderer.material.SetVector("_ObjectScreenPos", screenPoint);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == bubbleHead)
        {
            _renderer.material.SetVector("_HitPosition", bubbleHead.transform.position);
            StopAllCoroutines();
            StartCoroutine(Coroutine_HitDisplacementEXIT());
        }
    }
    IEnumerator Coroutine_HitDisplacementEXIT()
    {
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_DisplacementStrenght", _DisplacementCurveEXIT.Evaluate(lerp) * _DisplacementMagnitude);
            lerp += Time.deltaTime * _LerpSpeed;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bubbleHead)
        {
            _renderer.material.SetVector("_HitPosition", bubbleHead.transform.position);
            StopAllCoroutines();
            StartCoroutine(Coroutine_HitDisplacementENTER());
        }
    }
    IEnumerator Coroutine_HitDisplacementENTER()
    {
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_DisplacementStrenght", _DisplacementCurveENTER.Evaluate(lerp) * _DisplacementMagnitude);
            lerp += Time.deltaTime * _LerpSpeed;
            yield return null;
        }
    }
}
