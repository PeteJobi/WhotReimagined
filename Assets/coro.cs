using UnityEngine;
using System.Collections;

public class coro : MonoBehaviour
{
    public Color StartColor = Color.green;
    public Color EndColor = Color.red;
    public float TransitionTime = 5f;

    private Material _myMaterial;
    // Just to make sure we don't try to lerp if we're already doing so
    private bool _transitioning = false;

    private void Awake()
    {
        _myMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_transitioning)
        {
            StartCoroutine(DoLerp());
        }
    }

    private IEnumerator DoLerp()
    {
        _transitioning = true;

        float timeElapsed = 0f;
        float totalTime = TransitionTime;

        Color startColor = StartColor;
        Color endColor = EndColor;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            _myMaterial.color = Color.Lerp(startColor, endColor, timeElapsed / totalTime);
            Debug.Log(_myMaterial.color);
            yield return null;
        }

        _transitioning = false;
    }
}