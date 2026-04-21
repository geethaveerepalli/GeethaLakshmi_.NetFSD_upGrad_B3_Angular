const getWeatherPromise = () => {

    const city = document.getElementById("city").value;
    const resultDiv = document.getElementById("result");

    if (!city) {
        resultDiv.innerHTML = `<p style="color:red;">Please enter a city name</p>`;
        return;
    }

    fetch(`https://geocoding-api.open-meteo.com/v1/search?name=${city}`)
        .then(response => response.json())
        .then(geoData => {

            if (!geoData.results) {
                throw new Error("City not found");
            }

            const latitude = geoData.results[0].latitude;
            const longitude = geoData.results[0].longitude;

            return fetch(`https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`);
        })
        .then(response => response.json())
        .then(weatherData => {

            const weather = weatherData.current_weather;

            resultDiv.innerHTML = `
                <h3>Weather Report (Promise)</h3>
                <p><strong>City:</strong> ${city}</p>
                <p>Temperature: ${weather.temperature}°C</p>
                <p>Wind Speed: ${weather.windspeed} km/h</p>
            `;
        })
        .catch(error => {
            resultDiv.innerHTML = `<p style="color:red;">Error: ${error.message}</p>`;
        });
};


const getWeatherAsync = async () => {

    const city = document.getElementById("city").value;
    const resultDiv = document.getElementById("result");

    if (!city) {
        resultDiv.innerHTML = `<p style="color:red;">Please enter a city name</p>`;
        return;
    }

    try {
        const geoResponse = await fetch(`https://geocoding-api.open-meteo.com/v1/search?name=${city}`);
        const geoData = await geoResponse.json();

        if (!geoData.results) {
            throw new Error("City not found");
        }

        const latitude = geoData.results[0].latitude;
        const longitude = geoData.results[0].longitude;

        const weatherResponse = await fetch(
            `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`
        );

        const weatherData = await weatherResponse.json();
        const weather = weatherData.current_weather;

        resultDiv.innerHTML = `
            <h3>Weather Report (Async/Await)</h3>
            <p><strong>City:</strong> ${city}</p>
            <p>Temperature: ${weather.temperature}°C</p>
            <p>Wind Speed: ${weather.windspeed} km/h</p>
        `;

    } catch (error) {
        resultDiv.innerHTML = `<p style="color:red;">Error: ${error.message}</p>`;
    }
};