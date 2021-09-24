import { Component, Input } from '@angular/core';
import { Weather } from '@data/schema/weather';

@Component({
  selector: 'app-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.scss'],
})
export class CurrentWeatherComponent {
  @Input() weather: Weather;
}
