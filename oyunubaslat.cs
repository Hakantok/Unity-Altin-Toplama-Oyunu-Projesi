using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyunubaslat : MonoBehaviour
{
    public void BaslatButton()
	{
		SceneManager.LoadScene(1);
	}

	public void CýkýsButton()
	{
		Application.Quit();
	}


}
