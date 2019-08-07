using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnd : MonoBehaviour
{
    private float watchTime;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        watchTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Finish") {
            if (SceneManager.GetActiveScene().name == "level1"){
                Application.LoadLevel("level2");
            }else {
                score.curTime += watchTime;
                score.upadteBestTime();
                Application.LoadLevel("menu");
            }
        }
        if (other.gameObject.tag == "Start"){
            watchTime = 0;
            score.curTime = 0;
        }
    }
}
