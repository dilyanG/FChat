import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GroupType } from 'src/assets/enums';
import { MessageService } from 'src/app/services/message.service';
import { MessageModel } from 'src/app/models/message.model';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

  @Input() groupType: GroupType;

  messages: MessageModel[] = [];

  userId: number = 0;

  newMessage: string;
  lastMessage: string = new Date().toLocaleString();

  constructor(private messageService: MessageService,
    private userService: UserService, ) { }

  ngOnInit() {
    if (this.userService.loggedUser)
      this.userId = this.userService.loggedUser.id;
    this.messageService.getMessages(this.groupType).subscribe(
      res => {
        if (res) {
          this.messages = res;
          setInterval(() => {
            this.syncMessages();
          }, 2000);
        }
      }
    );
  }

  sendText() {
    let messageObject: MessageModel = new MessageModel();
    messageObject.groupTypeId = this.groupType;
    messageObject.user = this.userService.loggedUser;
    messageObject.message = this.newMessage;
    this.messageService.sendMessage(messageObject).subscribe(
      res => {
        this.messages = [...this.messages, messageObject];
        this.newMessage = null;
        this.lastMessage = new Date().toLocaleString();
      }
    )
  }

  syncMessages() {
    this.messageService.syncMessages(this.groupType, this.lastMessage).subscribe
      (
        res => {
          if (res) {
            this.messages = [...this.messages, ...res];
            if (this.messages.length > 0) {
              this.lastMessage = new Date(Math.max.apply(null, this.messages.map(function (e) {
                return new Date(e.createdOn);
              }))).toLocaleString();
            }
          }
        }
      )
  }

}
