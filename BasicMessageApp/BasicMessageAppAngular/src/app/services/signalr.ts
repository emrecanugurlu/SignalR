import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { sendMessage } from '@microsoft/signalr/dist/esm/Utils';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection!: signalR.HubConnection;

  startConnection = (hubUrl: string) => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(hubUrl)
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connection Started'))
      .catch((err) => console.log('Error while starting SignalR connection: ' + err));
  }

  addMessageListener = (methodName: string, callback: (...args: any[]) => void) => {
    this.hubConnection.on(methodName, (message: string) => {
      callback(message);
    }
    );
  }

  sendMessage = (methodName: string, ...args: any[]) => {
    this.hubConnection.invoke(methodName, ...args)
      .catch((err) => console.error('Error while sending message: ' + err));
  }

}