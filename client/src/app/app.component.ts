import { Component, Input, NgZone } from '@angular/core';
import { Message } from './shared/Message';
import { Chat } from './services/chat.service';

@Component({
  selector: 'chat-app',
  templateUrl: "./app.component.html",
  styles: []
})
export class AppComponent {
    title = 'Chat Application';
}
