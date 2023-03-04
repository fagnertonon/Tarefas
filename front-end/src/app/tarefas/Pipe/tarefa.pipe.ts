import { Pipe, PipeTransform } from '@angular/core';
import { Tarefa } from '../models/tarefa';

@Pipe({
  name: 'filtroTarefa',
  pure: false,
})
export class FiltroTarefaPipe implements PipeTransform {
  transform(items: any[], callback: (item: any) => boolean): any {
    if (!items || !callback) {
      return items;
    }
    return items.filter((item) => callback(item));
  }
}
