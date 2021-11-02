function attachEvents() {
    const validConditins = ['Rain', 'Degrees', 'Overcast', 'Partly sunny', 'Sunny']
    const requestedLocation = document.querySelector('#location');
    const submitBtn = document.querySelector('#submit');
    const forecast = document.querySelector('#forecast');
    submitBtn.addEventListener('click', getForecast)

    async function getForecast() {
        const current = document.querySelector('#current');
        const upcoming = document.querySelector('#upcoming');
        forecast.style.display = 'block';

        if(current.children.length > 1) {
            current.removeChild(current.children[1]);
            upcoming.removeChild(upcoming.children[1]);
        }

        try {
            const code = await getLocationCode();
            
            if(code == undefined) {
                throw new Error('Invalid location name.');
            }

            const [todayData, upcomingData] = await Promise.all([
                getData('today', code), 
                getData('upcoming', code)
            ]);
           
            const forecastDiv = createForecast(todayData);  
            const upcomingDiv = createUpcoming(upcomingData);
            upcoming.appendChild(upcomingDiv);
            current.appendChild(forecastDiv);

        } catch(error) {
            current.appendChild(createHtmlElement('div', { className: "forecasts" }, 'Error'));
            upcoming.appendChild(createHtmlElement('div', { className: "forecast-info" }, 'Error'));
        }
    }

    async function getLocationCode() {
        const res = await fetch('http://localhost:3030/jsonstore/forecaster/locations');

        if(res.ok !== true || res.status !== 200) {
            throw new Error('Bad request.');
        }

        const data = await res.json();

        const locationName = requestedLocation.value.trim();

        for(const location of data) {
            if(location.name === locationName) {
                return location.code;
            }
        }

        return undefined;
    }

    async function getData(condition, code) {
        let url = `http://localhost:3030/jsonstore/forecaster/${condition}/${code}`;
        const res = await fetch(url);

        if(res.ok !== true || res.status !== 200) {
            throw new Error('Bad request.');
        }

        const data = await res.json();
        return data;
    }

    function createHtmlElement(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }
        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    } 
    
    function getSymbol(weather) {
        let symbol = '';
        switch(weather) {
            case 'Rain': symbol = '&#x2614;'; break;
            case 'Degrees': symbol = '&#176;'; break;
            case 'Overcast': symbol = '&#x2601;'; break;
            case 'Partly sunny': symbol = '&#x26C5;'; break;
            case 'Sunny': symbol = '&#x2600;'; break;
            default: 
                throw new Error('Invalid weather symbol.')
        }

        return symbol;
    }

    function createForecast(data) {
        const condition = data.forecast.condition;
        const low = Number(data.forecast.low);
        const high = Number(data.forecast.high);
        const locationName = data.name;

        if(!validConditins.includes(condition)
          || isNaN(data.forecast.low)
          || isNaN(data.forecast.high)
          || low > high){
            throw new Error('Invalid data.');
        }

        const weatherSymbol = getSymbol(condition);
        const degreesSymbol = getSymbol('Degrees');

        const conditionSymbolSpan = createHtmlElement('span', { className: "condition symbol" });
        conditionSymbolSpan.innerHTML = weatherSymbol;
        const degreesSpan = createHtmlElement('span', { className: "forecast-data" });
        degreesSpan.innerHTML = `${low}${degreesSymbol}/${high}${degreesSymbol}`;
        const conditionSpan = createHtmlElement('span', { className: "condition" },
                                    createHtmlElement('span', { className: "forecast-data" }, `${locationName}`),
                                    degreesSpan,
                                    createHtmlElement('span', { className: "forecast-data" }, `${condition}`));

        const forecastDiv = createHtmlElement('div', { className: "forecast" },
                                conditionSymbolSpan,
                                conditionSpan);
        return forecastDiv;
    }
    
    function createUpcoming(data) {
        const forecastInfoDiv = createHtmlElement('div', { className: "forecast-info" });

        data.forecast.forEach(currData => {
            const condition = currData.condition; 
            const low = Number(currData.low);
            const high = Number(currData.high);

            if(!validConditins.includes(condition)
            || isNaN(currData.low)
            || isNaN(currData.high)
            || low > high){
              throw new Error('Invalid data.');
          }

            const weatherSymbol = getSymbol(condition);
            const degreesSymbol = getSymbol('Degrees');

            const conditionSymbolSpan = createHtmlElement('span', { className: "condition symbol" });
            conditionSymbolSpan.innerHTML = weatherSymbol;
    
            const degreesSpan = createHtmlElement('span', { className: "forecast-data" });
            degreesSpan.innerHTML = `${low}${degreesSymbol}/${high}${degreesSymbol}`;
    
            const upcomingSpan = createHtmlElement('span', { className: "upcoming" },
                                        conditionSymbolSpan,
                                        degreesSpan,
                                        createHtmlElement('span', { className: "forecast-data" }, `${condition}`));
    
            forecastInfoDiv.appendChild(upcomingSpan);
        });
       
        return forecastInfoDiv;
    }
}

attachEvents();