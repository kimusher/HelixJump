using System;

using UnityEngine;
// ReSharper disable All

public class PlatformPassDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (transform.gameObject.tag == "PassPlatform")
        {
            Debug.Log(string.Format("{0} DESTROYED", transform.parent.gameObject.name));
            Destroy(transform.parent.gameObject); // Destroys the whole floor
            Ball.scoreInRow++;
            Debug.Log(string.Format("Score in row: {0}", Ball.scoreInRow));
        }
    }
}
