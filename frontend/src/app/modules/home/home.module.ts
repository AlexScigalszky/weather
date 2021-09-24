import { NgModule } from '@angular/core';
import { HomeComponent } from './page/home.component';
import { HomeRoutingModule } from './home.routing';
import { SharedModule } from '@shared/shared.module';
import { HomeAuthResolver } from './home-auth-resolver.service';
import { WeatherTableComponent } from './components/weather-table/weather-table.component';
import { CurrentWeatherComponent } from './components/current-weather/current-weather.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CityFormComponent } from './components/city-form/city-form.component';
import { MaterialModule } from '@shared/material.module';

@NgModule({
  declarations: [
    HomeComponent,
    CityFormComponent,
    WeatherTableComponent,
    CurrentWeatherComponent,
  ],
  imports: [
    SharedModule,
    HomeRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  exports: [],
  providers: [HomeAuthResolver],
  entryComponents: [
    WeatherTableComponent,
    CurrentWeatherComponent,
    CityFormComponent,
  ],
})
export class HomeModule {}
