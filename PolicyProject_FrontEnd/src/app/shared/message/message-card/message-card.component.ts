import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-card',
  templateUrl: './message-card.component.html',
  styleUrls: ['./message-card.component.css']
})
export class MessageCardComponent implements OnInit {

  constructor() { }
  @Input() status:{message:string,error:boolean}={message:"",error:true}
  

  clickHandle(){
    this.status.message='';
  }

  ngOnInit(): void {
  }

}
