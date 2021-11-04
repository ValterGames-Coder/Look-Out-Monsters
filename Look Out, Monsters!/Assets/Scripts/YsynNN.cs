using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class YsynNN : MonoBehaviour
{
    public Image bar;
    int SceneID;
    public Text SceneTextID;
    public int minLevel, maxLevel;
    void Start()

    {
        StartCoroutine(Anys());
    }

    public IEnumerator Anys()
    {
        SceneID = Random.Range(minLevel, maxLevel);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            bar.fillAmount = progress;
            SceneTextID.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
