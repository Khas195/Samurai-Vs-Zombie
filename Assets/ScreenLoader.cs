using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScreenLoader : MonoBehaviour {

    public string sceneName;
    public Image loadingBar;
    float loadingProcess;
	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	public void LoadScene()
    {
        Debug.Log("Load Scene");
        this.gameObject.SetActive(true);
        StartCoroutine(LoadingScene());
    }
    IEnumerator LoadingScene()
    {
        loadingBar.transform.localScale = new Vector3(loadingProcess, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);
        AsyncOperation async = Application.LoadLevelAsync(sceneName);
        while (!async.isDone)
        {
            loadingProcess = async.progress * 100;
            Debug.Log(loadingProcess);
            loadingBar.transform.localScale = new Vector3(async.progress, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);
            yield return null;
        }
    }
}
