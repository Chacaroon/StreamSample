import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { map, Observable, of, shareReplay, switchMap, tap } from "rxjs";
import { ControlType } from "../../types/control.type";
import { TodoListModel } from "../../models/todo-list.model";
import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { HttpClient } from "@angular/common/http";
import { TodoItemModel } from "../../models/todo-item.model";

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TodoItemComponent implements OnInit {

  form$: Observable<ControlType<TodoListModel>>;

  constructor(private route: ActivatedRoute,
              private http: HttpClient,
              private router: Router) {
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    const form$ = of(new FormGroup({
      id: new FormControl<number>(0),
      name: new FormControl<string>("", [ Validators.required ]),
      tags: new FormControl<string[]>([]),
      items: new FormArray<ControlType<TodoItemModel>>([])
    }));

    this.form$ = !id
      ? form$
      : form$.pipe(
        switchMap(form => this.http.get<TodoListModel>(`/todolist/${id}`).pipe(
          tap(x => form.patchValue(x)),
          tap(x => this.addItems(form.controls.items, x.items)),
          map(() => form))
        ),
        shareReplay(1)
      );
  }

  addItems(formArray: FormArray<ControlType<TodoItemModel>>, values: Partial<TodoItemModel>[]) {
    for (let value of values) {
      formArray.push(new FormGroup({
        id: new FormControl<number | null>(value.id ?? 0),
        name: new FormControl<string | null>(value.name ?? null),
        done: new FormControl<boolean | null>(value.done ?? false)
      }));
    }
  }

  onSubmit(form: ControlType<TodoListModel>) {
    if (form.invalid) {
      return;
    }

    if (!form.value.id) {
      this.http.post('/todolist', form.value).subscribe(x => this.router.navigateByUrl('/'));
    }
    else {
      this.http.put('/todolist', form.value).subscribe(x => this.router.navigateByUrl('/'));
    }
  }

  // region TagsHelpers

  addTag(value: string, tags: FormControl<string[] | null>) {
    tags.setValue([...(tags.value ?? []), value]);
  }

  removeTag(index: number, tags: FormControl<string[] | null>) {
    const value = [...(tags.value ?? [])];
    value.splice(index, 1);
    tags.setValue(value);
  }

  // endregion
}
