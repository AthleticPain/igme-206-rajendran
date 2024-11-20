using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrail : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> trails;

    [SerializeField] float lerpDuration = 1;
    [SerializeField] float forwardLifetime = 0.1f;
    [SerializeField] float backwardsLifetime = 0.0f;

    private float targetLifetime;

    private List<Coroutine> lerpLifetimeCoroutines;

    private void Awake()
    {
        lerpLifetimeCoroutines = new List<Coroutine>();
        foreach (ParticleSystem trail in trails)
        {
            lerpLifetimeCoroutines.Add(null);
        }
    }

    public void ChangeTrailLifetime(bool forwardDirection)
    {
        float newTargetLifetime = forwardDirection ? forwardLifetime : backwardsLifetime;

        if (newTargetLifetime != targetLifetime)
        {
            targetLifetime = newTargetLifetime;


            for (int i = 0; i < trails.Count; i++)
            {
                if (lerpLifetimeCoroutines[i] != null)
                {
                    StopCoroutine(lerpLifetimeCoroutines[i]);
                }

                lerpLifetimeCoroutines[i] = StartCoroutine(LerpTrailLifetime(trails[i], newTargetLifetime));
            }

        }
    }

    private IEnumerator LerpTrailLifetime(ParticleSystem trailRenderer, float targetLifetime)
    {
        var main = trailRenderer.main;

        float initialLifetime = main.startLifetime.constant;
        float timeElapsed = 0f;

        while (Mathf.Abs(trailRenderer.time - targetLifetime) > 0.01f) // Small tolerance to stop
        {
            main.startLifetime = Mathf.Lerp(initialLifetime, targetLifetime, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        main.startLifetime = targetLifetime;
    }
}
