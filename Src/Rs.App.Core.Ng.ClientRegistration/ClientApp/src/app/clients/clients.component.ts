import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client-api/client.service';

import {ClientInfo} from '../ViewModels/IClientInfo';
import { ISubscriberCallback } from '../ViewModels/ISubscriberCallback';
import { ModalService } from '../_modal/modal.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  clients: ClientInfo[];
  selectClient: ClientInfo;
  constructor(private clientService: ClientService,
    private modalService: ModalService) {

   }

  ngOnInit() {
    this.clientService.getClients()
      .subscribe( 
        n=> this.next(n),
        (error) => this.error(error),
        () => this.completed()
      );      
  }

  openClientInfo(id: string, client: ClientInfo): void{
    this.selectClient = client;
    this.modalService.open(id);
  }

  closeModal(id:string){
    this.modalService.close(id);
  }
  
  completed(): void {
    
  }
  next(value: any): void {
    this.clients = value;    
  }
  error(error: any): void {
    console.log(error.error);
  }
}
