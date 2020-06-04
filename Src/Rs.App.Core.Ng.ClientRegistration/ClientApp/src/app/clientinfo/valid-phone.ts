import { AbstractControl, ValidatorFn } from "@angular/forms";


export function validPhone(reg: RegExp): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
        let value = control.value;

        if(value == '' || value == undefined || value == null){
            return null;
        }

      const isValid = reg.test(value);
      return !isValid ? {'regphonenumber': {value: control.value}} : null;
    };
  };