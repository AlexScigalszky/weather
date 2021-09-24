import { Injectable } from '@angular/core';
import { ApiService } from '@app/service/api.service';
import { BaseList } from '@data/schema/base-list';
import { Weather } from '@data/schema/weather';
import { WeatherQuery } from '@data/schema/weather-query';
import { SerializerService } from '@shared/service/serializer.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  static GET_CURRENT = '/Weather/GetCurrent/';
  static GET_HISTORICAL = '/Weather/Historical/';

  constructor(
    private api?: ApiService,
    private serializer?: SerializerService,
  ) {}

  getCurrentOfCity(cityId: number): Observable<Weather> {
    return this.api.get(`${WeatherService.GET_CURRENT}${cityId}`);
  }

  getHistoricalOfCity(query: WeatherQuery): Observable<BaseList<Weather>> {
    const queryParams = this.serializer.queryToParams(query);
    return this.api.get(`${WeatherService.GET_HISTORICAL}${queryParams}`);
  }
}
