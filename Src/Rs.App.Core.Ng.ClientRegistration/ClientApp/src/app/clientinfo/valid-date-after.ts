import { AbstractControl, ValidatorFn } from "@angular/forms";


export function validPassedDate(year: number): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
        let value = control.value;

        if(value == '' || value == undefined || value == null){
            return null;
        }
        var date = new Date(value);

      const isNotValid = date.getFullYear() <= year;
      return isNotValid ? {'passeddate': {value: control.value}} : null;
    };
  };