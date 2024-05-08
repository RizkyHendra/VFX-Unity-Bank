using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public iTween.EaseType movementEaseType = iTween.EaseType.easeInOutSine;
    public float movementRadius = 30;
    public float movementSpeed = .5f;

    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(Movement());
    }



    IEnumerator Movement()
    {
        var newPos = new Vector3 (originalPosition.x + Random.Range(-movementRadius, movementRadius), originalPosition.y, originalPosition.z + Random.Range(-movementRadius, movementRadius));
        var distance = newPos - originalPosition;
        var time = distance.magnitude / movementSpeed;

        iTween.MoveTo(gameObject, iTween.Hash("position", newPos, " easeType", movementEaseType, "time", time));
        yield return new WaitForSeconds(time + .1f);
        StartCoroutine(Movement());
    }

   
}
