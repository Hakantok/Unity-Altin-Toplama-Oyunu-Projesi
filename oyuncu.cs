using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncu : MonoBehaviour
{

	public Animator animasyon;

	public GameObject bitti_pnl;

	public TMPro.TextMeshProUGUI puan_txt;
	public TMPro.TextMeshProUGUI toplanan_altin_txt;

	public Transform alan1;
	public Transform alan2;
	public Transform duvar1;
	public Transform duvar2;

	public Rigidbody rigi;

	bool sag = true;

	int puan = 0;
	int toplanan_altin = 0;

	public bool miknatis_alindi = false;


	
	   private void Start()
	{
		bitti_pnl = GameObject.Find("bitti_pnl");
		bitti_pnl.SetActive(false);
	}
    

	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "duvar1")
		{
			alan2.position = new Vector3(alan1.position.x, alan1.position.y, alan1.position.z - 30.0f);
		}

		if (other.gameObject.name == "duvar2")
		{
			alan1.position = new Vector3(alan2.position.x, alan2.position.y, alan2.position.z - 30.0f);
		}

		if (other.gameObject.tag == "engel")
		{
			Debug.Log("carptý");
			bitti_pnl.SetActive(true);
			Time.timeScale = 0.0f;
		}

		if (other.gameObject.tag == "altin")
		{
			toplanan_altin++;
			puan += 5;
			Destroy(other.gameObject);

			puan_txt.text = puan.ToString("000000");
			toplanan_altin_txt.text = toplanan_altin.ToString();
		}

		if (other.gameObject.tag == "miknatis")
		{
			GameObject[] tum_miknatislar = GameObject.FindGameObjectsWithTag("miknatis");

			foreach (GameObject miknatis in tum_miknatislar)
			{
				Destroy(miknatis);
			}

			miknatis_alindi = true;
			Invoke("miknatisi_resetle", 10.0f);
		}
	}

	void miknatisi_resetle()
	{
		miknatis_alindi = false;
	}

     void Update()
	{
		hareket();
	}

	void hareket()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			animasyon.SetBool("zipla", true);
			rigi.velocity = Vector3.up * 300.0f * Time.deltaTime;
			Invoke("ziplama_iptal", 0.5f);
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			sag = true;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			sag = false;
		}

		if (sag)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(17.0f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(13.0f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
		}

		transform.Translate(0, 0, 5 * Time.deltaTime);
	}

	void ziplama_iptal()
	{
		animasyon.SetBool("zipla", false);
	}
}

