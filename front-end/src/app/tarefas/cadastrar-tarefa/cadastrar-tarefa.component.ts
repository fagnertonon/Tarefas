import {
  Component,
  OnInit,
  AfterViewInit,
  ElementRef,
  ViewChildren,
} from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControlName,
} from '@angular/forms';

import { Observable, fromEvent, merge } from 'rxjs';
import { Status } from '../models/status';
import { Tarefa } from '../models/tarefa';
import { TarefaService } from '../tarefas_service';

import {
  DisplayMessage,
  GenericValidator,
  ValidationMessages,
} from '../generic-form-validation';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-tarefa',
  templateUrl: './cadastrar-tarefa.component.html',
  styles: [],
})
export class CadastrarTarefaComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  cadastroForm: FormGroup;
  tarefa: Tarefa = new Tarefa();

  status: Status[];

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage;

  constructor(
    private tarefaService: TarefaService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.validationMessages = {
      descricao: { required: 'Descrição é requerido' },
      data: { required: 'Data é requerido' },
      statusId: { required: 'Status é requerido' },
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    this.cadastroForm = this.fb.group({
      descricao: ['', Validators.required],
      dataPrevisao: ['', Validators.required],
      statusId: ['', Validators.required],
    });

    this.tarefaService.obterStatus().subscribe((status) => {
      this.status = status;
    });
  }

  adicionarTarefa() {
    if (!this.cadastroForm.valid) return;

    this.tarefa = Object.assign({}, this.tarefa, this.cadastroForm.value);
    this.tarefaService
      .adicionarTarefa(this.cadastroForm.value)
      .subscribe(() => {
        this.router.navigate(['/tarefas']);
      });
  }
}
