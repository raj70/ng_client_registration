import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-clientinfo',
  templateUrl: './clientinfo.component.html',
  styleUrls: ['./clientinfo.component.css']
})

/** https://angular.io/guide/reactive-forms */

export class ClientinfoComponent implements OnInit {

  constructor() { }

  clientRegForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    dob: new FormControl(''),
    phonenumber: new FormControl(''),    
    emailAddress: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
    address: new FormGroup({
      line1: new FormControl(''),
      line2: new FormControl(''),
      line3: new FormControl(''),
      suburb: new FormControl(''),
      postcode: new FormControl(''),
      country: new FormControl(''),
    })
  }) ;

  ngOnInit() {
  }

  onSubmit() {
    console.warn(this.clientRegForm.value);
  }
}
