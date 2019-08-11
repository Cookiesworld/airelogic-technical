import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BugListComponent } from './bug-list/bug-list.component';


const routes: Routes = [
  {path: 'bugs', component: BugListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
