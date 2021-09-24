import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Weather } from '@data/schema/weather';

@Component({
  selector: 'app-weather-table',
  templateUrl: './weather-table.component.html',
  styleUrls: ['./weather-table.component.scss'],
})
export class WeatherTableComponent {
  @Input() weatherList: Weather[] = [];
  @Output() orderByChanged = new EventEmitter<string>();

  orderByCountry(): void {
    this.orderByChanged.emit('Country');
  }

  orderByCity(): void {
    this.orderByChanged.emit('City');
  }
}
