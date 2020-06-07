import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client-api/client.service';

import {ClientInfo} from '../ViewModels/IClientInfo';
import { ISubscriberCallback } from '../ViewModels/ISubscriberCallback';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  clients: ClientInfo[];
  constructor(private clientService: ClientService) {

   }

  ngOnInit() {
    this.clientService.getClients()
      .subscribe( 
        n=> this.next(n),
        (error) => this.error(error),
        () => this.completed()
      );      
  }

  
  completed(): void {
    console.log("Finished");
  }
  next(value: any): void {
    this.clients = value;    
  }
  error(error: any): void {
    console.log(error.error);
  }
}
