import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Departamentos, Funcionários } from '../models/models';
import { Service } from '../services/service';

@Component({
    selector: 'app-Departamentos',
    templateUrl: './departamentos.component.html',
})

export class DepartamentoComponent implements OnInit {
  
  depId = this.route.snapshot.paramMap.get('id');
  
  funcionários = new Funcionários();
  ffuncionários = new Funcionários();
  fnome = 's';
  erro: any;
  id: any;
  public selectedFuncionário: string;
  public selectedFuncionário2: string
  
  funcionárioput: Departamentos;
  funcionáriopost: Departamentos;
  formFuncionárioPut = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    rg: new FormControl(''),
    foto: new FormControl(''),
    departamentoId: new FormControl('')
  });
  
  formFuncionárioPost = new FormGroup({
    nome: new FormControl(''),
    rg: new FormControl(''),
    foto: new FormControl(''),
    departamentoId: new FormControl('')
  });
  


  constructor(
    private Service: Service,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) {
    
    this.getfuncionários();
    
    this.criarFormPost();
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id']; 
    });
      }

  getfuncionários() {
    this.Service.getfuncionáriosbydi(this.depId).subscribe((data: Funcionários) => {
      this.funcionários = data
      console.log(" data que recebemos", this.funcionários);
      console.log(" variavel que preenchemos", data);
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }
  getfuncionáriosbyid() {
    this.Service.getFuncionáriosByID(this.depId).subscribe((data: Funcionários) => {
      this.ffuncionários = data
      console.log("data que recebemos", this.funcionários);
      console.log("variavel que preenchemos", data);
      return data
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }

  selectFuncionário(funcionário: any) {
    this.selectedFuncionário = funcionário;
    this.criarForm(funcionário);
  }
  selectFuncionário2(funcionário2: any) {
    this.selectedFuncionário2 = funcionário2;
  }
  
  criarForm(funcionário: Funcionários) {
    this.formFuncionárioPut = this.fb.group({
      id: [funcionário.id],
      name: [funcionário.nome],
      rg: [funcionário.rg],
      foto: [funcionário.foto],
      departamentoId: [funcionário.departamentoId]
    });
  }

  criarFormPost() {
    this.formFuncionárioPost = this.fb.group({
      nome: [this.funcionários.nome],
      rg: [this.funcionários.rg],
      foto: [this.funcionários.foto],
      departamentoId: [this.depId]
    });
  }

  
  reloadComponent() {
    setTimeout(() => {
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    }, 1000)
    
  }


  saveFuncionárioPost() {

    this.funcionáriopost = this.formFuncionárioPost.value;
    console.log(this.funcionáriopost);
    this.sendpostrequest();

    this.reloadComponent();

  }
  sendpostrequest() {
    this.Service.postFuncionários(this.funcionáriopost).subscribe(
      (funcionário: any) => { console.log(funcionário) },
      (erro: any) => { console.log(erro) }
    );
  }
  
  deleteFuncionário(id) {
    this.Service.deleteFuncionários(id).subscribe(
      (id: any) => { console.log(id) },
      (error: any) => { console.log(error) }
    );
    this.reloadComponent();
  }

  
  saveFuncionário() {
    this.funcionárioput = this.formFuncionárioPut.value;

    console.log(this.funcionárioput);
    this.sendputrequest();
    this.reloadComponent();

  }
  sendputrequest() {
    this.Service.putFuncionários(this.funcionárioput).subscribe(
      (departamento: any) => { console.log(departamento) },
      (erro: any) => { console.log(erro) }
    );
  }

}
