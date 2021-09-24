import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { City } from '@data/schema/city';

export type CityFilter = {
  cityId: number;
  historical: boolean;
};

@Component({
  selector: 'app-city-form',
  templateUrl: './city-form.component.html',
  styleUrls: ['./city-form.component.scss'],
})
export class CityFormComponent implements OnInit {
  @Output() onSubmited = new EventEmitter<CityFilter>();
  @Input() cities: City[] = [];

  INPUT_CITY = 'city';
  INPUT_HISTORICAL = 'historical';

  cityForm: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.cityForm = this.fb.group({
      city: [this.cities?.length ? this.cities[0] : null],
      historical: [false],
    });
  }

  submit() {
    const formResult = {
      cityId: parseInt(this.cityForm.get('city').value, 10),
      historical: this.cityForm.get('historical').value,
    };
    this.onSubmited.emit(formResult);
  }
}
