import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Message } from "../shared/Message";

@Injectable()
export class Chat {

    constructor(private http: HttpClient) {

    }

    public messages: Message[] = [];

    loadMessages(): Observable<void> {
        return this.http.get<[]>("/api/messages")
            .pipe(map(data => {
            this.messages = data;
            return;
        }));
    }
}