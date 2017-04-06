using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullRomController : MonoBehaviour {

    public Transform p0, p1, p2, p3;
    public GameObject mover;

    private GameObject objRef;
    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
        objRef = Instantiate(mover, p0.transform.position, p0.transform.rotation);
	}

    // Update is called once per frame
    void Update() {
        Vector3 newPos = Vector3.zero;

        timer += Time.deltaTime;

        newPos = 0.5f * (
            (2 * p1.position) +
            (-p0.position + p2.position) * timer +
            (2 * p0.position - 5 * p1.position + 4 * p2.position - p3.position) * timer * timer +
            (-p0.position + 3 * p1.position - 3 * p2.position + p3.position) * timer * timer * timer);

        objRef.transform.position = newPos;

        if (timer > 1.0f)
        {
            timer = 1.0f;
        }
        
	}
}
