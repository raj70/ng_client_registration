import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISubscriberCallback } from 'src/app/ViewModels/ISubscriberCallback';

@Injectable({
  providedIn: 'root',
})
export class ClientService {

  constructor(private httpClient: HttpClient) { }

  postClient(data: any, subscriberCallback: ISubscriberCallback): void{
     this.httpClient.post("/api/v01/clientregistrations", data)
     .subscribe(
        value => subscriberCallback.next(value),
        (error) => subscriberCallback.error(error),
        () => subscriberCallback.completed()
      );
  };

  getClients(subscriberCallback: ISubscriberCallback): void{
    this.httpClient.get("/api/v01/clientregistrations")
    .subscribe(
        value =>subscriberCallback.next(value),
        error=> subscriberCallback.error(error),
        () => subscriberCallback.completed()
    );
  };
}
