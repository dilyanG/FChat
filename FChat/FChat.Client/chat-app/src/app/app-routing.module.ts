import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EnterComponent } from './components/enter/enter.component';
import { ChatComponent } from './components/chat/chat.component';


const routes: Routes = [
  { path: '', component: EnterComponent },
  { path: 'chat/:id', component: ChatComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
