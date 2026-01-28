import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SignalrService } from './services/signalr';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private readonly signalrService = inject(SignalrService);
  messages: string[] = [];
  newMessage = '';

  ngOnInit(): void {
    this.signalrService.startConnection('https://localhost:7155/messagehub');
    this.signalrService.addMessageListener('ReceiveMessage', (user: string, message: string) => {
      this.messages.push(`${user}: ${message}`);
    });
  }

  send(userName: string, message: string): void {
    this.signalrService.sendMessage('SendMessageAsync', userName, message);
  }

}
