import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/shared/contact/contact.model';
import { ContactService } from 'src/app/shared/contact/contact.service';

@Component({
  selector: 'app-contact-display',
  templateUrl: './contact-display.component.html',
  styleUrls: ['./contact-display.component.css']
})
export class ContactDisplayComponent implements OnInit {
  contacts:Contact[];
  constructor(public contactService:ContactService) { }

  ngOnInit(): void {
    this.contactService.getAllContacts().subscribe(res=>{
      this.contacts= res as Contact[];
    },err=>console.log(err))
  }

}
