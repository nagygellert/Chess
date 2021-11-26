import { Pipe, PipeTransform } from '@angular/core';
import { Column } from '../models/column';

@Pipe({
  name: 'columnName'
})
export class ColumnNamePipe implements PipeTransform {

  transform(value: Column): string {
    return Column[value];
  }

}
