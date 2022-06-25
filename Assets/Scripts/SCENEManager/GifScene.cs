using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GifScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoNextScene());
    }

    IEnumerator GoNextScene(){
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("GameScene");
    }
}
