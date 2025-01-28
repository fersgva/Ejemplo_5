using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mainMixer;

    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject optionsMenuPanel;

    [SerializeField]
    private TMP_Dropdown qualityDropdown;

    [SerializeField]
    private TMP_Dropdown resolutionsDropdown;


    private Resolution[] resolutions; //Resoluciones disponibles en mi pantalla.

    private List<string> resolutionsOptions = new List<string>();
    private void Start()
    {
        InitResolutionDropdown();



        //Inicializar el dropdown con el valor por defecto de nivel de calidad.
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue(); //Refresco los valores.

        resolutionsDropdown.value = GetDefaultResolution();
        resolutionsDropdown.RefreshShownValue();

    }

    private void InitResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        foreach (var resolution in resolutions)
        {
            resolutionsOptions.Add(resolution.width + "x" + resolution.height);
        }
        resolutionsDropdown.AddOptions(resolutionsOptions);
    }

    private int GetDefaultResolution()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenuPanel.SetActive(true);
            optionsMenuPanel.SetActive(false);
        }
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    //Se ejecuta cuando clickemos el bot�n de opciones.
    public void OnOptionsButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }
    public void OnQuitButtonClicked()
    {
        Debug.Log("Juego cerrado");
        Application.Quit();
    }

    public void SetNewVolumeToMusic(float volume)
    {
        mainMixer.SetFloat("musicVolume", volume);
    }
    public void SetNewVolumeToSounds(float volume)
    {
        mainMixer.SetFloat("soundsVolume", volume);
    }

    public void SetNewFullScreenState(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetNewQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetNewResolution(int  resolutionIndex)
    {
        Debug.Log("xffff");
        Resolution chosenResolution = resolutions[resolutionIndex];
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);
    }
}
