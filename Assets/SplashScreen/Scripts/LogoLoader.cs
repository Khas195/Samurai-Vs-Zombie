using UnityEngine;
using System.Collections;

public class LogoLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Countdown");
	}

    private void StartCoroutine()
    {
        throw new System.NotImplementedException();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(8.2f);
        Application.LoadLevel(1);
    }
}
