import { Injectable } from '@angular/core';
import { ApiService } from '@app/service/api.service';
import { City } from '@data/schema/city';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  static GET_BENEFITS = '/City/GetCities';

  constructor(private api?: ApiService) {}

  getAll(): Observable<City[]> {
    return this.api.get(CitiesService.GET_BENEFITS);
  }
}
