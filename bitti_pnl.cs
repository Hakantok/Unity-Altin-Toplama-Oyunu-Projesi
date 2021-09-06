using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bitti_pnl : MonoBehaviour
{
	public void EvetButton()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(1);
	}


	public void HayirButton()
	{
		SceneManager.LoadScene(0);
	}


}
