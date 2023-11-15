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

    [Header("Path Limits")]
    [SerializeField]private float minX = default;
    [SerializeField]private float maxX = default;
    [SerializeField]private float minY = default;
    [SerializeField]private float maxY = default;

    private bool phase3TransitionStarted = default;

    private void Start()
    {
        originalPosition = transform.position;

        GeneratePath(minX, maxX, minY, maxY);
        _movementSpeed = movementSpeed;
    }

    private void Update()
    {
        if (Boss3PhaseManager.instance.phase1) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition) GeneratePath(minX, maxX, minY, maxY);
        }
        else if (Boss3PhaseManager.instance.phase2) {
            movementSpeed = _movementSpeed * 1.5f;
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition) GeneratePath(minX, maxX, minY, maxY);
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
        // yield return new WaitForSeconds(2);
        transform.position += transform.up * movementSpeed;
        yield return new WaitForSeconds(2);
    }

    private void GeneratePath(float _minX, float _maxX, float _minY, float _maxY)
    {
        startPosition = transform.position;
        endPosition = new Vector3(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }
}
