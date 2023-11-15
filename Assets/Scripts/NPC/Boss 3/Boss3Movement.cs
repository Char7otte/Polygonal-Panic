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
            MoveToPosition(movementSpeed);
        }
        else if (Boss3PhaseManager.instance.phase2) {
            MoveToPosition(movementSpeed * 1.5f);
            GameObject sprite = CheckForSpriteRenderer();
        }
        else if (Boss3PhaseManager.instance.phase3) {
            transform.position += transform.up * movementSpeed * Time.deltaTime * 2;
            if(transform.position.y > 20) this.gameObject.SetActive(false);
        }
        else if (Boss3PhaseManager.instance.phase4) {
            print("rotation started.");
            GameObject sprite = CheckForSpriteRenderer();
            sprite.transform.Rotate(0, 0, 45 * Time.deltaTime);
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

    private void MoveToPosition(float _movementSpeed) {
        float distCovered = (Time.time - startTime) * _movementSpeed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        if (transform.position == endPosition) GeneratePath(minX, maxX, minY, maxY);
    }

    private GameObject CheckForSpriteRenderer() {
        SpriteRenderer _spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            Debug.Log("Child with SpriteRenderer found: " + _spriteRenderer.gameObject.name);
            return _spriteRenderer.gameObject;
        }
        else
        {
            Debug.Log("No child with SpriteRenderer found.");
            return null;
        }
    }
}
