import { Component, OnInit } from '@angular/core';
import { GroupType } from 'src/assets/enums';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  groupType = GroupType;
  userId: number;

  constructor( private userService:UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userId = +params.get('id');
      this.userService.getUser(this.userId).subscribe(
        res=>{
          this.userService.loggedUser = res;
        }
      )
    });
  }

}
