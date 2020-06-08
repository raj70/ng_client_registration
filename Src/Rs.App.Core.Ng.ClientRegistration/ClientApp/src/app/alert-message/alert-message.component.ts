import { Component, OnInit, Input } from '@angular/core';
import { enumMessageType } from '../ViewModels/Enums';

@Component({
  selector: 'app-alert-message',
  templateUrl: './alert-message.component.html',
  styleUrls: ['./alert-message.component.css']
})
export class AlertMessageComponent implements OnInit {

  @Input()
  messageCss: string = 'alert-warning';
  @Input()
  errorMessage: string = '';

  constructor() { }

  ngOnInit() {
  }

  resetError(message: string){
    this.errorMessage = message;
  }
}
