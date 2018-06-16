using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI : MonoBehaviour {

    [SerializeField]
    private GameObject _World;
    [SerializeField]
    private Text _WorldSizeText;
    [SerializeField]
    private Text _TimeText;
    [SerializeField]
    private Text _StartText;

    private void Start()
    {
        _TimeText.enabled = false;
        _WorldSizeText.enabled = false;
    }

    float time = 0;
	void Update ()
    {
        if (!scr_Game.Get.GameRunning)
        {
            if(Input.GetKeyDown(scr_Keys.StartGame))
            {
                _TimeText.enabled = true;
                _WorldSizeText.enabled = true;
                _StartText.enabled = false;
                scr_Game.Get.StartGame();
            }
        }
        else
        {
            time += Time.deltaTime;

            _WorldSizeText.text = _World.transform.localScale.x.ToString("0") + " m";
            int min = (int)(time / 60);
            int sec = (int)(time % 60);
            float ms = (float)(time % 1) * 1000;

            _TimeText.text = min.ToString("00") + "." + sec.ToString("00") + ":" + ms.ToString("000");
        }
	}
}
