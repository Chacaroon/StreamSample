import { TodoItemModel } from "./todo-item.model";
import { FormValue } from "./form-value.model";

export interface TodoListModel {
  id: number;
  name: string;
  tags: FormValue<string[]>;
  items: TodoItemModel[];
}
