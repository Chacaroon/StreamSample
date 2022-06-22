import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { FormValue } from "../models/form-value.model";

export type ControlType<T> =
  T extends boolean
    ? FormControl<boolean | null>
    : T extends string | number | Date
      ? FormControl<T | null>
      : T extends FormValue<infer TInner>
        ? FormControl<TInner | null>
        : T extends (infer TCollectionItem)[]
          ? FormArray<ControlType<TCollectionItem>>
          : FormGroup<{ [key in keyof T]: ControlType<T[key]> }>;
