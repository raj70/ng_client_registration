import { AbstractControl, ValidatorFn } from "@angular/forms";


export function validFutureDate(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
        let value = control.value;

        if(value == '' || value == undefined || value == null){
            return null;
        }
        var date = new Date(value);

      const isNotValid = date.getFullYear() >= new Date().getFullYear();
      return isNotValid ? {'futuredate': {value: control.value}} : null;
    };
  };