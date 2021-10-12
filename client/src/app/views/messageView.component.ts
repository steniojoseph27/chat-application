import { Component, OnInit } from "@angular/core";
import { Chat } from "../services/chat.service";


@Component({
    selector: "message-list",
    templateUrl: "messageView.component.html",
    styleUrls: ["messageView.component.css"]
})
export default class MessageListView implements OnInit{

    constructor(public chat: Chat) {
    }
    ngOnInit(): void {
        this.chat.loadMessages()
            .subscribe(() => {

            });
    }
}