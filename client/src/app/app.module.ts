import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { Chat } from './services/chat.service';
import MessageView from './views/messageView.component';

@NgModule({
  declarations: [
      AppComponent,
      MessageView
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
    providers: [
        Chat
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
