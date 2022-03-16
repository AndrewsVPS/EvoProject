import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
})

export class FormComponent implements OnInit {

  departamentoput: any;
  formDepartamento = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    sigla: new FormControl('')
  });

  constructor() { }
  ngOnInit() { }

  formput() {
    this.departamentoput = this.formDepartamento.value;
  }
}
