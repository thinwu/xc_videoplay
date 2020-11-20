using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    
    public List<Attributes> CharacterAttribute;
    private void Awake() {
        GetComponent<Button>().onClick.AddListener(AsyncClick);
    }
    public void AsyncClick()
    {
        foreach (Attributes a in CharacterAttribute)
        {
            if (Attributes.CharacterStatistic.ContainsKey(a.characterAttri))
            {
                Attributes.CharacterStatistic[a.characterAttri] += a.Value;
            }
            else
            {
                Attributes.CharacterStatistic.Add(a.characterAttri, a.Value);
            }
            
        }
        foreach (Attributes.CharacterAttribute a in Attributes.CharacterStatistic.Keys)
        {
            Debug.Log(a + ": " + Attributes.CharacterStatistic[a]);
        }
        StartCoroutine(LoadAsyncScene());
    }
    private IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
