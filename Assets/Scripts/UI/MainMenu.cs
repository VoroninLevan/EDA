using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private UnityEngine.UI.Text header;
    [SerializeField] private Button scanButton;
    [SerializeField] private Button hiwButton;

    private int _screenWidth, _screenHeight;
    private const double WidthPercentage = 25.0;
    private const double HeightPercentage = 20.0;

    // Start is called before the first frame update
    private void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        CalculateMainMenuButtonDimensions();
    }

    private void CalculateMainMenuButtonDimensions()
    {
        int dynamicButtonWidth = (int)((WidthPercentage * 100) * _screenWidth);
        int dynamicButtonHeight = (int)((HeightPercentage * 100) * _screenHeight);

        //scanButton.GetComponent<RectTransform>().localScale = new Vector3(0.25f,0.2f,1);
    }
}
