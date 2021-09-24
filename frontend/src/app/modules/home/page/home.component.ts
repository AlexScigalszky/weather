import { Component, OnInit } from '@angular/core';
import { BaseList } from '@data/schema/base-list';
import { Nullable } from '@data/schema/nullable';
import { Weather } from '@data/schema/weather';
import { CitiesService } from '@data/service/cities.service';
import { WeatherService } from '@data/service/weather.service';
import { PaginationComponent } from '@shared/component/pagination/pagination.component';
import { BehaviorSubject, combineLatest, forkJoin, Observable, of } from 'rxjs';
import {
  distinctUntilChanged,
  filter,
  flatMap,
  map,
  tap,
} from 'rxjs/operators';
import { CityFilter } from '../components/city-form/city-form.component';

export type ApiData = {
  current: Weather;
  historical: Nullable<BaseList<Weather>>;
};

export type Pagination = {
  pageNumber: number;
  pageSize: number;
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  triggerSubject = new BehaviorSubject<CityFilter>(null);
  // pagination
  paginationSubject = new BehaviorSubject<Pagination>({
    pageNumber: 1,
    pageSize: PaginationComponent.DEFAULT_PAGE_SIZE,
  });
  // order by
  orderBySubject = new BehaviorSubject<string>('City');
  //Cities
  cities$ = this.citiesService.getAll();
  // API Data
  apiData$: Observable<ApiData> = combineLatest([
    this.triggerSubject.asObservable().pipe(filter((x) => x !== null)),
    this.paginationSubject.asObservable().pipe(distinctUntilChanged()),
    this.orderBySubject.asObservable().pipe(distinctUntilChanged()),
  ]).pipe(
    tap((x) => (this.isLoading = true)),
    map(([filter, pagination, orderBy]) => ({ filter, pagination, orderBy })),
    flatMap((data) =>
      forkJoin([
        this.weatherService.getCurrentOfCity(data.filter.cityId),
        this.historical(data),
      ]).pipe(map(([current, historical]) => ({ current, historical }))),
    ),
    tap((x) => (this.isLoading = false)),
    tap(console.log),
  );
  // loading
  isLoading = false;

  constructor(
    private citiesService: CitiesService,
    private weatherService: WeatherService,
  ) {}

  historical = (data: {
    filter: CityFilter;
    pagination: Pagination;
    orderBy: string;
  }) =>
    data.filter.historical
      ? this.weatherService.getHistoricalOfCity({
          cityId: data.filter.cityId,
          pageNumber: data.pagination.pageNumber,
          pageSize: data.pagination.pageSize,
          orderBy: data.orderBy,
        })
      : of(null);

  onSearch = (params: CityFilter) => this.triggerSubject.next(params);

  paginationChange = (pagination: Pagination) =>
    this.paginationSubject.next(pagination);

  orderByChange = (orderBy: string) => this.orderBySubject.next(orderBy);
}
