﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

    public void OnRetry()
    {
        SceneManager.LoadScene(0);
    }

}
