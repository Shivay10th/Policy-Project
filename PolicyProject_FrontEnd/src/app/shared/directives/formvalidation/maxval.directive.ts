import { Directive,Input } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[appMaxval]'
  ,providers:[
    {
      provide:NG_VALIDATORS,
      useExisting:MaxvalDirective,
      multi:true
    }
  ]
})
export class MaxvalDirective implements Validator {

  @Input('appMaxval') maxValue :string
  validate(control: AbstractControl): ValidationErrors | null{
      let v= +control.value
    if(isNaN(v)){
      return {"maxVal":true}
    }
    if(v > parseInt(this.maxValue)){
      return {"maxVal":true}
    }
    return null;  
  }

}
