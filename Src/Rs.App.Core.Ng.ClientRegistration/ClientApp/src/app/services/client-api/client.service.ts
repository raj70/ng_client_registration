import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ClientInfo, ClientInfoReg } from 'src/app/ViewModels/IClientInfo';
import { ISubscriberCallback } from 'src/app/ViewModels/ISubscriberCallback';

@Injectable({
  providedIn: 'root',
})
export class ClientService {

  clientUrl: string = "/api/V01/clientregistrations";

  constructor(private httpClient: HttpClient) { }

  postClient(data: any, subscriberCallback: ISubscriberCallback): void{
    this.httpClient.post(this.clientUrl, data)
    .subscribe(
       value => subscriberCallback.next(value),
       (error) => subscriberCallback.error(error),
       () => subscriberCallback.completed()
     );
  };
  
  getClients(): Observable<ClientInfo[]>{
    return this.httpClient.get<ClientInfo[]>(this.clientUrl)
    .pipe(
      /* https://angular.io/tutorial/toh-pt6#error-handling */
      catchError(this.handleError<ClientInfo[]>('getClients', []))
    );   
  };

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
