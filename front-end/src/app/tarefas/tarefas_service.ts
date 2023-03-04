import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Tarefa } from './models/tarefa';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Status } from './models/status';

@Injectable()
export class TarefaService {
  constructor(private http: HttpClient) {}
  protected UrlServiceV1: string = 'https://localhost:7202/api';

  protected endPointTarefa: string = 'tarefa';

  obterTarefas(): Observable<Tarefa[]> {
    // const url = `${this.UrlServiceV1}/${this.endPointTarefa}/obter-todos`;
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}`;
    var response = this.http
      .get<Tarefa[]>(url)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));

    return response;
  }

  obterTarefasPorId(id: number): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}/${id}`;
    return this.http
      .get<Tarefa>(url)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  adicionarTarefa(tarefa: Tarefa): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}`;
    console.log(url);
    return this.http
      .post<Tarefa>(url, tarefa)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  atualizarTarefa(tarefa: Tarefa): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}`;
    return this.http
      .put(url, tarefa)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  excluir(id: string): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}/${id}`;
    return this.http
      .delete<Tarefa>(url)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  concluirTarefa(tarefa: Tarefa): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}/concluir/${tarefa.id}`;
    return this.http
      .put(url, {tarefa})
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  desenvolverTarefa(tarefa: Tarefa): Observable<Tarefa> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}/desenvolver/${tarefa.id}`;
    return this.http
      .put(url, tarefa)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  obterStatus(): Observable<Status[]> {
    const url = `${this.UrlServiceV1}/${this.endPointTarefa}/status`;
    return this.http
      .get<Status[]>(url)
      .pipe(map(this.extrairDataModel), catchError(this.serviceError));
  }

  extrairDataModel(response: any) {
    return response.model || {};
  }

  serviceError(response: Response | any) {
    let customError: string[] = [];
    let customResponse = { error: { errors: [] } };

    if (response instanceof HttpErrorResponse) {
      if (response.statusText === 'Unknown Error') {
        customError.push('Ocorreu um erro desconhecido');
        response.error.errors = customError;
      }
    }
    if (response.status === 500) {
      customError.push(
        'Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.'
      );

      // Erros do tipo 500 não possuem uma lista de erros
      // A lista de erros do HttpErrorResponse é readonly
      customResponse.error.errors = customError;
      return throwError(customResponse);
    }

    console.error(response);
    return throwError(response);
  }
}
