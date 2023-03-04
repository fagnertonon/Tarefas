import {
  Component,
  OnInit,
  AfterViewInit,
  ElementRef,
  ViewChildren,
  Input,
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
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editar-tarefa',
  templateUrl: './editar-tarefa.component.html',
  styles: [],
})
export class EditarTarefaComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  public tarefa: Tarefa = new Tarefa();

  editarForm: FormGroup;

  status: Status[];

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage;

  constructor(
    private tarefaService: TarefaService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.validationMessages = {
      descricao: { required: 'Descrição é requerido' },
      dataPrevisao: { required: 'Data Prevista é requerido' },
      statusId: { required: 'Status é requerido' },
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    
    this.editarForm = this.fb.group({
      descricao: ['', Validators.required],
      dataPrevisao: ['', Validators.required],
      statusId: ['', Validators.required],
    });

    this.route.params.subscribe((params) => {
      this.tarefaService.obterTarefasPorId(params['id']).subscribe((tarefa) => {
        this.tarefa = tarefa;
        this.preencherFormulario();
      });

      this.tarefaService.obterStatus().subscribe((status) => {
        this.status = status;
      });
    });
  }

  preencherFormulario(){
    let date = new Date();
     date.toLocaleDateString().substring(0,10)
    this.editarForm.patchValue({
      id: this.tarefa.id,
      descricao: this.tarefa.descricao,
      dataPrevisao: this.formatDate(this.tarefa.dataPrevisao),
      status: this.tarefa.status,
      statusId:this.tarefa.statusId
    });
    console.log(this.tarefa);
  }

  adicionarTarefa() {
    if (!this.editarForm.valid) return;

    this.tarefa = Object.assign({}, this.tarefa, this.editarForm.value);
    
    this.tarefaService.atualizarTarefa(this.tarefa).subscribe(() => {
        this.router.navigate(['/tarefas']);
      });
  }

  private formatDate(date) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('-');
  }
}
