using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingFilesBar : MonoBehaviour
{
		public GameObject LoadingText;
		public Text ProgressIndicator;
		public Image LoadingBar;
		float currentValue;
		public float speed;
		public EnvironmentSportsHall scriptA;
		public EnvironmentReverberationRoom scriptB;

		// Use this for initialization
		void Start()
		{
		    speed = .97f;
			scriptA = GameObject.Find("Canvas").GetComponent<EnvironmentSportsHall>();
			scriptB = GameObject.Find("Canvas").GetComponent<EnvironmentReverberationRoom>();

		}

		// Update is called once per frame
		void Update()
		{
			if (currentValue < 100)
			{
				currentValue += speed * Time.deltaTime;
				ProgressIndicator.text = ((int)currentValue).ToString() + "%";
				LoadingText.SetActive(true);
			}
			else
			{
				LoadingText.SetActive(false);
				ProgressIndicator.gameObject.SetActive(false);
				LoadingBar.gameObject.SetActive(false);

				if (SceneManager.GetActiveScene().buildIndex == 1)
				{
					scriptA.Play.gameObject.SetActive(true);



				}
				else
				{
					scriptB.Play.gameObject.SetActive(true);
				}

			}

			LoadingBar.fillAmount = currentValue / 100;
		}
	}

