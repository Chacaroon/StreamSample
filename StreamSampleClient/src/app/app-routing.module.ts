import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodoListsComponent } from "./components/todo-lists/todo-lists.component";
import { TodoItemComponent } from "./components/todo-item/todo-item.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: TodoListsComponent
  },
  {
    path: 'todo-list',
    component: TodoItemComponent
  },
  {
    path: 'todo-list/:id',
    component: TodoItemComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
