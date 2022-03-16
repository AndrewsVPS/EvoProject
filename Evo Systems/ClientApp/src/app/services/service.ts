import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departamentos } from '../../app/models/models';

@Injectable({
  providedIn: 'root'
})
export class Service {

  basef = "http://localhost:23283/api/funcionários";
  based = "http://localhost:23283/api/departamentos"

  constructor(private http: HttpClient) { }
  public getDepartamentos(): Observable<any> {
    return this.http.get("http://localhost:44365/api/departamentos");
  }
  public getFuncionários(): Observable<any> {
    return this.http.get("http://localhost:44365/api/funcionários");
  }
  public getfuncionáriosbydi(id: any): Observable<any> {
    return this.http.get(`${this.basef}/${id}`);
  }
  public postDepartamento(departamento: any) {
    return this.http.post("http://localhost:44365/api/departamentos", departamento);
  }
  public putDepartamento(departamento: Departamentos) {
    return this.http.put<JSON>(`${this.based}`, departamento);
  }
  public postFuncionários(funcionários: any) {
    return this.http.post("http://localhost:44365/api/funcionários", funcionários);
  }
  public putFuncionários(funcionários: any) {
    return this.http.put(`${this.basef}`, funcionários);
  }
  public deleteFuncionários(id: any) {
    return this.http.delete(`${this.basef}/${id}`);
  }
  public deleteDepartamento(id: any) {
    return this.http.delete(`${this.based}/${id}`);
  }
  public getFuncionáriosByID(id: any) {
    return this.http.get(`${this.based}/one/${id}`)
  }
}
