import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { ClientService } from '../services/client-api/client.service';
import { ValidationService } from './validation.service';
import { ISubscriberCallback } from '../ViewModels/ISubscriberCallback';
import { enumMessageType } from '../ViewModels/Enums';

@Component({
  selector: 'app-clientinfo',
  templateUrl: './clientinfo.component.html',
  styleUrls: ['./clientinfo.component.css'],
  providers: [ValidationService]
})
/** https://angular.io/guide/reactive-forms */

export class ClientinfoComponent implements OnInit {

  errorMessage = '';
  messageCss = '';

  constructor( private clientService: ClientService,
    private inputValidation: ValidationService) { 
    this.errorMessage = '';
    this.messageCss = 'alert-warning';
  }

  clientRegForm = new FormGroup({
    firstName: new FormControl('',[
      Validators.required,
      Validators.maxLength(60)
    ]),
    lastName: new FormControl('',[
      Validators.required,
      Validators.maxLength(60)
    ]),
    dob: new FormControl('',[
      Validators.required,
      this.inputValidation.validFutureDate(),
      this.inputValidation.validPassedDate(1923)
    ]),
    phonenumber: new FormControl('',[
      Validators.required,
      this.inputValidation.validPhone(new RegExp("^(?!-)[0-9\\-?]{8,15}$"))
    ]),    
    emailAddress: new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    password: new FormControl('',
      [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(30),     
        this.inputValidation.validPassword(new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})"))   
      ]),
    confirmPassword: new FormControl(''),
    address: new FormGroup({
      line1: new FormControl('',[
        Validators.required,
        Validators.maxLength(60)
      ]),
      line2: new FormControl(''),
      line3: new FormControl(''),
      suburb: new FormControl('',[
        Validators.required,
        Validators.maxLength(30)
      ]),
      postcode: new FormControl('',[
        Validators.required,
        Validators.maxLength(8)
      ]),
      country: new FormControl('',[Validators.required]),
    })
  }) ;

  ngOnInit() {
  }

  onSubmit() {
    this.resetMessageWithMessageType("Loading...", enumMessageType.info) 
    const clientReg = this.clientService.postClient(this.clientRegForm.value,this);
  };

  resetError(message: string){
    this.errorMessage = message;
  }

  resetMessageWithMessageType(message: string, typeOfMessage: enumMessageType){
    if(typeOfMessage == enumMessageType.error){
      this.messageCss = 'alert-danger';
    }
    else if(typeOfMessage == enumMessageType.info){
      this.messageCss = 'alert-info';
    }
    else{
      this.messageCss = 'alert-warning';
    }

    this.errorMessage = message;
  }

  
  completed(): void {
    this.resetMessageWithMessageType("Registration Completed", enumMessageType.info) 
  }
  next(value: any): void {
    console.log(value);
  }
  error(error: any): void {
    console.log(error.error);
    this.resetMessageWithMessageType(error.error, enumMessageType.error);
  }

  /** https://angular.io/guide/form-validation#built-in-validator-functions */
  get firstName() { return this.clientRegForm.get('firstName'); }
  get lastName() { return this.clientRegForm.get('lastName'); }
  get dob() { return this.clientRegForm.get('dob'); }
  get phonenumber() { return this.clientRegForm.get('phonenumber'); }
  get emailAddress() { return this.clientRegForm.get('emailAddress'); }
  get password() { return this.clientRegForm.get('password'); }
  get confirmPassword() { return this.clientRegForm.get('confirmPassword'); }
  get line1() { return this.clientRegForm.get('address.line1'); }
  get line2() { return this.clientRegForm.get('address.line2'); }
  get line3() { return this.clientRegForm.get('address.line3'); }
  get suburb() { return this.clientRegForm.get('address.suburb'); }
  get postcode() { return this.clientRegForm.get('address.postcode'); }
  get country() { return this.clientRegForm.get('address.country'); }
}
