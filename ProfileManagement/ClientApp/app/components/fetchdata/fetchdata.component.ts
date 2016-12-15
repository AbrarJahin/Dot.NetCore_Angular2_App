import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { WeatherForecast } from '../../dataModel/WeatherForecast.ts';   //Data Model

@Component({
    selector: 'fetchdata',
    template: require('./fetchdata.component.html')
})

export class FetchDataComponent
{
    public forecasts: WeatherForecast[];

    constructor(http: Http) {
        http.get('/api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json();
        });
    }
}