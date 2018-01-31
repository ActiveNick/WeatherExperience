using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if WINDOWS_UWP
using OpenWeatherLib;
#endif

public class Weather : MonoBehaviour {

    private Text _myText;  // The Text field on the canvas used to output messages in this demo

#if WINDOWS_UWP
    // Define the OpenWeatherMap service object for REST weather data calls
    OpenWeatherMapService owms;
#endif

    // Use this for initialization
    void Start () {

        _myText = GameObject.Find("DebugText").GetComponent<Text>();

#if WINDOWS_UWP
        owms = new OpenWeatherMapService();
#endif
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Clears the Canvas output text
    public void ClearOutput()
    {
        _myText.text = string.Empty;
    }

    // Appends a string to a new line in the canvas output text
    public void WriteLine(string s)
    {
        if (_myText.text.Length > 20000)
            _myText.text = string.Empty + "-- TEXT OVERFLOW --";

        _myText.text += s + "\r\n";
    }

    public async void Button_GetWeather()
    {
#if WINDOWS_UWP
    
        var wr = await owms.GetWeather("Princeton,NJ");
        if (wr != null)
        {
            var weatherText = "The current temperature in {0} is {1}°F, with a high today of {2}° and a low of {3}°.";
            WriteLine(weatherText);
        }
#else
        WriteLine("The Weather library only works in UWP in this test app.");
#endif
    }
}
