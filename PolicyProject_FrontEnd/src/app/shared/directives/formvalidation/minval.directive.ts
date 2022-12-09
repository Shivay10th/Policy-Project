import { Directive,Input } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[appMinval]',providers:[{
      provide:NG_VALIDATORS,
      useExisting:MinvalDirective,
      multi:true
    }]
})
export class MinvalDirective implements Validator {

  @Input('appMinval') minValue:string

  validate(control: AbstractControl): ValidationErrors|null {
    let v= +control.value
    if(isNaN(v)){
      return {"minVal":true}
    }
    if(v<= parseInt(this.minValue)){
      return {"minVal":true}
    }
    return null;    

  }

}
