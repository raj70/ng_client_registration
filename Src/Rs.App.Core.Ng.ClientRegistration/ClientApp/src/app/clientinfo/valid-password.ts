import { AbstractControl, ValidatorFn } from "@angular/forms";


export function validPassword(reg: RegExp): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
        let value = control.value;

        if(value == '' || value == undefined || value == null){
            return null;
        }
        
      const isValid = reg.test(value);
      console.log(value, isValid, reg.source);
      return !isValid ? {'validpassword': {value: control.value}} : null;
    };
  };