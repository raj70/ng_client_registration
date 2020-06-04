import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clientinfo',
  templateUrl: './clientinfo.component.html',
  styleUrls: ['./clientinfo.component.css']
})

/** https://angular.io/guide/reactive-forms */

export class ClientinfoComponent implements OnInit {

  constructor() { }

  clientRegForm = new FormGroup({
    firstName: new FormControl('',[Validators.required]),
    lastName: new FormControl('',[Validators.required]),
    dob: new FormControl(''),
    phonenumber: new FormControl('',[Validators.required]),    
    emailAddress: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required]),
    confirmPassword: new FormControl(''),
    address: new FormGroup({
      line1: new FormControl('',[Validators.required]),
      line2: new FormControl(''),
      line3: new FormControl(''),
      suburb: new FormControl('',[Validators.required]),
      postcode: new FormControl('',[Validators.required]),
      country: new FormControl('',[Validators.required]),
    })
  }) ;

  ngOnInit() {
  }

  onSubmit() {
    console.warn(this.clientRegForm.value);
  }
}
