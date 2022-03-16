import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Departamentos, Funcionários } from '../../app/models/models'
import { Service } from '../services/service'
import { ActivatedRoute, Router } from '@angular/router';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Metodo não implementado.');
  }
  departamentos = new Departamentos();
  erro: any;
  id: number;
  public selectedDepartamento: string;
  public selectedDepartamento2: string;

  departamentoput: Departamentos;
  departamentopost: Departamentos;
  formDepartamento = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    sigla: new FormControl('')
  });

  formDepartamentoPost = new FormGroup({
    nome: new FormControl(''),
    sigla: new FormControl('')
  });

  constructor(
    private service: Service,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) {

    this.getDepartamentos();

  }

  criarForm(dep: Departamentos) {
    this.formDepartamento = this.fb.group({
      id: [dep.id],
      nome: [dep.nome],
      sigla: [dep.sigla]
    });
  }

  criarFormPost() {
    this.formDepartamentoPost = this.fb.group({
      nome: [''],
      sigla: ['']
    });
  }

  getDepartamentos() {
    this.service.getDepartamentos().subscribe((data: Departamentos) => {
      this.departamentos = data
      console.log("o data q recebemos", this.departamentos);
      console.log("a variavel q preenchemos", data);
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }

  deleteDepartamento(id) {
    this.service.deleteDepartamento(id).subscribe(
      (id: any) => { console.log(id) },
      (error: any) => { console.log(error) }
    );
    this.reloadComponent();
  }

  reloadComponent() {
    let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate([currentUrl]);
  }

  selectDepartamento(departamento: any) {
    this.selectedDepartamento = departamento;
    this.criarForm(departamento);
  }
  selectDepartament2(departament2: any) {
    this.selectedDepartamento2 = departament2;
  }

  saveDepartamento() {
    this.departamentoput = this.formDepartamento.value;

    console.log(this.departamentoput);
    this.sendputrequest();
    this.reloadComponent();

  }

  sendputrequest() {
    this.service.putDepartamento(this.departamentoput).subscribe(
      (departament: any) => { console.log(departament) },
      (erro: any) => { console.log(erro) }
    );
  }

  saveDepartamentoPost() {

    this.departamentopost = this.formDepartamentoPost.value;
    console.log(this.departamentopost);
    this.sendpostrequest();

    this.reloadComponent();

  }

  sendpostrequest() {
    this.service.postDepartamento(this.departamentopost).subscribe(
      (departament: any) => { console.log(departament) },
      (erro: any) => { console.log(erro) }
    );
  }

}
