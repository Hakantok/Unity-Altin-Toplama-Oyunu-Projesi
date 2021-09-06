using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon_olustur : MonoBehaviour
{

	public GameObject altin;
	public GameObject tas;
	public GameObject kutuk;
	public GameObject miknatis;

	public Transform oyuncu;

	float silinme_zamani = 5.0f;

	float sag_X_koordinat = 13.0f;
	float sol_X_koordinat = 17.0f;

	void Start()
	{
		InvokeRepeating("nesne_klonla", 0, 0.5f);
	}


	void nesne_klonla()
	{
		int rastsayi = Random.Range(0, 120);

		if (rastsayi > 0 && rastsayi < 80)
		{
			klonla(altin, 0.5f);
		}
		if (rastsayi > 80 && rastsayi < 85)
		{
			klonla(kutuk, 0.2f);
		}
		if (rastsayi > 85 && rastsayi < 90)
		{
			klonla(tas, 0f);
		}
		if (rastsayi > 90 && rastsayi < 120)
		{
			if (oyuncu.gameObject.GetComponent<oyuncu>().miknatis_alindi == false)
			{
				klonla(miknatis, 0.5f);
			}
		}

		void klonla(GameObject nesne, float Y_koordinat)
		{
			GameObject yeni_klon = Instantiate(nesne);

			int rastsayi = Random.Range(0, 100);

			if (rastsayi < 50)
			{
				yeni_klon.transform.position = new Vector3(sag_X_koordinat, Y_koordinat, oyuncu.position.z - 20.0f);
			}
			else if (rastsayi > 50)
			{
				yeni_klon.transform.position = new Vector3(sol_X_koordinat, Y_koordinat, oyuncu.position.z - 20.0f);
			}
			Destroy(yeni_klon, silinme_zamani);
		}
	}
}

