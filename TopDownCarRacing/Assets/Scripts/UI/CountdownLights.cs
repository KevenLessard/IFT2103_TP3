using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class CountdownLights : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private List<Transform> lights;
    [SerializeField] private List<AudioSource> lightsSound;

    [SerializeField] private float animationTime;

    private Vector2[] _bezierControlPoints;

    private Coroutine _playAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _bezierControlPoints = new Vector2[4];
        _bezierControlPoints[0] = new Vector2(0, 0);
        _bezierControlPoints[1] = new Vector2(0, 0.89f);
        _bezierControlPoints[2] = new Vector2(1, -0.14f);
        _bezierControlPoints[3] = new Vector2(1, 1);
        foreach (var l in lights)
        {
            l.position = start.position;
        }
    }

    public IEnumerator PlayAnimation()
    {
        int currentLight = 0;
        while (currentLight < 4)
        {
            yield return StartCoroutine(Animation(currentLight));
            currentLight++;
        }
    }
    
    private IEnumerator Animation(int pCurrentLight)
    {
        float timeElapsed = 0;
        lightsSound[pCurrentLight].Play();
        while (timeElapsed < animationTime)
        {
            lights[pCurrentLight].position = LerpV3(start.position, end.position, GetBezierCubicPoint(timeElapsed / animationTime).y);
            timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }
    }

    private Vector3 LerpV3(Vector3 startValue, Vector3 endValue, float lerpValue)
    {
        Vector3 answer;
        answer.x = Mathf.Lerp(startValue.x, endValue.x, lerpValue);
        answer.y = Mathf.Lerp(startValue.y, endValue.y, lerpValue);
        answer.z = Mathf.Lerp(startValue.z, endValue.z, lerpValue);
        return answer;
    }

    private Vector2 GetBezierCubicPoint(float p)
    {
        Assert.IsTrue((p >= 0.0f) && (p <= 1.0f));
        float c = 1.0f - p;

        // The Bernstein polynomials.
        float bb0 = c*c*c;
        float bb1 = 3*p*c*c;
        float bb2 = 3*p*p*c;
        float bb3 = p*p*p;

        Vector2 point = _bezierControlPoints[0]*bb0 + _bezierControlPoints[1]*bb1 + _bezierControlPoints[2]*bb2 + _bezierControlPoints[3]*bb3;
        return point;
    }
}
