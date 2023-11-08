using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = default;
    private float _movementSpeed = default;

    private Vector3 startPosition = default;
    private Vector3 endPosition = default;
    private float startTime = default;
    private float journeyLength = default;

    private void Start()
    {
        GeneratePath();
        _movementSpeed = movementSpeed;
    }

    private void Update()
    {
        if (Boss3PhaseManager.instance.phase2) {
            movementSpeed = _movementSpeed * 1.5f;
        }

        float distCovered = (Time.time - startTime) * movementSpeed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);

        if (transform.position == endPosition) GeneratePath();
    }

    private void GeneratePath()
    {
        startPosition = transform.position;
        endPosition = GenerateDestinationVector();
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    private Vector3 GenerateDestinationVector()
    {
        var positionVector = new Vector3(Random.Range(-6, 6), Random.Range(1, 3.75f), 0);
        return positionVector;
    }
}
