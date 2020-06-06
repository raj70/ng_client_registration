import { Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  validPassword(reg: RegExp): ValidatorFn {
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

  validPhone(reg: RegExp): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
        let value = control.value;

        if(value == '' || value == undefined || value == null){
            return null;
        }

      const isValid = reg.test(value);
      return !isValid ? {'regphonenumber': {value: control.value}} : null;
    };
  };

  validFutureDate(): ValidatorFn {
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

  validPassedDate(year: number): ValidatorFn {
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
  
}
