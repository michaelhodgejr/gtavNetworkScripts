using System;
using GTANetworkServer;
using GTANetworkShared;

public class Weather : Script
{

    public Weather()
    {
        API.onResourceStart += myResourceStart;
    }

    public void myResourceStart()
    {
        API.consoleOutput("Starting weather plugin!");
    }

    [Command("weather", Description = "Sets the Worlds Weather")]
    public void SetWeather(Client player, string weather)
    {
        int weatherId = getWeatherIdFromString(weather);

        if(weatherId == -1)
        {
            // Invalid paramter passed in. Send a chat message showing the correct syntax.
            API.sendChatMessageToPlayer(player, "Invalid parameter passed to /weather. Valid options are: extrasunny, clear, clouds, smog, foggy, overcast, rain, thunder, lightrain, smoggylightrain, verylightsnow, lightsnow");
        }
        else
        {
           // Set the weather in the server.
           API.setWeather(weatherId);
        }
    }


    // Converts the weather string into an integer for use in the API.setWeather method.
    // Defaults to "extrasunny" if an invalid parameter is specified.
    protected int getWeatherIdFromString(string weather)
    {

        switch (weather.ToLower())
        {
            case "extrasunny":
                return 0;
            case "clear":
                return 1;
            case "clouds":
                return 2;
            case "smog":
                return 3;
            case "foggy":
                return 4;
            case "overcast":
                return 5;
            case "rain":
                return 6;
            case "thunder":
                return 7;
            case "lightrain":
                return 8;
            case "smoggylightrain":
                return 9;
            case "verylightsnow":
                return 10;
            case "windylightsnow":
                return 11;
            case "lightsnow":
                return 12;
            default:
                return -1;
        }
    }
}