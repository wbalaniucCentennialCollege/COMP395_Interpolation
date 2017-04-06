using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullRomController : MonoBehaviour {
    
    public GameObject mover;
    public GameObject point;
    public int numOfPoints = 20;

    private GameObject objRef;
    private float timer = 0.0f;
    private List<Transform> points;

    private int index0, index1, index2, index3;

	// Use this for initialization
	void Start () {
        points = new List<Transform>();

        for(int i = 0; i < numOfPoints; i++)
        {
            points.Add(Instantiate(point, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(0, 20.0f)), Quaternion.identity).transform);
        }

        objRef = Instantiate(mover, points[0].transform.position, points[0].transform.rotation);

        index0 = 0;
        index1 = index0 + 1;
        index2 = index0 + 2;
        index3 = index0 + 3;
	}

    // Update is called once per frame
    void Update() {
        Vector3 newPos = Vector3.zero;

        timer += Time.deltaTime;

        
        newPos = 0.5f * (
            (2 * points[index1].position) +
            (-points[index0].position + points[index2].position) * timer +
            (2 * points[index0].position - 5 * points[index1].position + 4 * points[index2].position - points[index3].position) * timer * timer +
            (-points[index0].position + 3 * points[index1].position - 3 * points[index2].position + points[index3].position) * timer * timer * timer);

        
        objRef.transform.position = newPos;

        if (timer > 1.0f)
        {
            timer = 0.0f;
            if (index0 + 1 > points.Count - 1)
                index0 = 0;
            else 
                index0++;

            if (index1 + 1 > points.Count - 1)
                index1 = 0;
            else
                index1++;

            if (index2 + 1 > points.Count - 1)
                index2 = 0;
            else
                index2++;

            if (index3 + 1 > points.Count - 1)
                index3 = 0;
            else
                index3++;

            
        }
        
	}
}
