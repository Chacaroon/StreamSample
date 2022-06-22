import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable, shareReplay } from "rxjs";
import { TodoListModel } from "../../models/todo-list.model";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-todo-lists',
  templateUrl: './todo-lists.component.html',
  styleUrls: ['./todo-lists.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TodoListsComponent implements OnInit {

  lists$: Observable<TodoListModel[]>;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.lists$ = this.http.get<TodoListModel[]>('/todolist').pipe(
      shareReplay(1)
    );
  }
}
