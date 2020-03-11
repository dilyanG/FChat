import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { GroupType } from 'src/assets/enums';
import { MessageModel } from '../models/message.model';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private http: HttpClient) { }

  getMessages(type: GroupType): Observable<MessageModel[]> {
    return this.http.get<MessageModel[]>(environment.webApp + "message/all/"+type);
  }
  syncMessages(type: GroupType, after: string): Observable<MessageModel[]> {
    return this.http.get<MessageModel[]>(environment.webApp + "message/sync?type="+type+"&after="+after);
  }

  sendMessage(message: MessageModel) {
    return this.http.post(environment.webApp + "message/add", message);
  }
}
