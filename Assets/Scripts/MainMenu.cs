using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
	[Header("Volume Setting")]
	[SerializeField] private TMP_Text volumeTextValue = null;
	[SerializeField] private Slider volumeSlider = null;

	[SerializeField] private GameObject confirmationPrompt = null;

    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}

	public void SetVolume(float volume){
		AudioListener.volume = volume;
		volumeTextValue.text = volume.ToString("0.0");
	}

	public void VolumeApply(){
		PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
		//show prompt
		StartCoroutine(ConfirmationBox());
	}

	public IEnumerator ConfirmationBox(){
		confirmationPrompt.SetActive(true);
		yield return new WaitForSeconds(2);
		confirmationPrompt.SetActive(false);
	}
}
