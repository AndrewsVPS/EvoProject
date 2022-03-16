import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Funcionários',
  templateUrl: './funcionários.component.html'
})
export class FuncionáriosComponent {
  public forecasts: Funcionários[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Funcionários[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Funcionários {
  id: number;
  nome : string;
  rg: number;
  foto: string;
  departamentoid: number;
}
