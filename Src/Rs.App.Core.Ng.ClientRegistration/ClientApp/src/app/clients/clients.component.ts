import { Component } from '@angular/core';
import { ClientService } from '../services/client-api/client.service';

import {ClientInfo} from '../ViewModels/IClientInfo';
import { ISubscriberCallback } from '../ViewModels/ISubscriberCallback';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements ISubscriberCallback {

  clients: ClientInfo[];
  constructor(private clientService: ClientService) {

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

  ngOnInit() {
    console.log("onInit");
    this.clientService.getClients(this);
  }

}
