using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = default;
    private float _movementSpeed = default;

    private Vector3 startPosition = default;
    private Vector3 originalPosition = default;
    private Vector3 endPosition = default;
    private float startTime = default;
    private float journeyLength = default;

    private bool phase3TransitionStarted = default;

    private void Start()
    {
        originalPosition = transform.position;

        GeneratePath(-6, 6, 1, 3.75f);
        _movementSpeed = movementSpeed;
    }

    private void Update()
    {
        if (Boss3PhaseManager.instance.phase1) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition) GeneratePath(-6, 6, 1, 3.75f);
        }
        else if (Boss3PhaseManager.instance.phase2) {
            movementSpeed = _movementSpeed * 1.5f;
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition) GeneratePath(-6, 6, 1, 3.75f);
        }
        else if (Boss3PhaseManager.instance.phase3 && !phase3TransitionStarted) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, originalPosition, fractionOfJourney);

            if (transform.position == originalPosition) StartCoroutine(Phase3Transition());
        }
    }

    IEnumerator Phase3Transition() {
        phase3TransitionStarted = true;
        yield return new WaitForSeconds(2);
        transform.position += transform.up * movementSpeed;
        yield return new WaitForSeconds(2);
        //this.gameObject.SetActive(false);
    }

    private void GeneratePath(float minX, float maxX, float minY, float maxY)
    {
        startPosition = transform.position;
        endPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }
}
