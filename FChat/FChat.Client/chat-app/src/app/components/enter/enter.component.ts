import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { Routes, RouterModule, Router } from "@angular/router";

@Component({
  selector: 'app-enter',
  templateUrl: './enter.component.html',
  styleUrls: ['./enter.component.css']
})
export class EnterComponent implements OnInit {

  user: UserModel = new UserModel();
  taken: boolean = true;
  constructor(private userService: UserService,
    private router: Router) { }

  ngOnInit() {
  }

  enter() {
    this.userService.enter(this.user).subscribe(
      res => {
        if (res) {
          this.userService.loggedUser = res as UserModel;
          this.router.navigate([`/chat/${this.userService.loggedUser.id}`]);
        }
      }
    )
  }

  onNameChange(name: string) {
    if (name) {
      this.userService.checkUser(name).subscribe(
        res => {
          if (!res) this.taken = false;
          else this.taken = true;
        }
      )
    }
  }

}
