import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/shared/contact/contact.model';
import { ContactService } from 'src/app/shared/contact/contact.service';

@Component({
  selector: 'app-contact-reg',
  templateUrl: './contact-reg.component.html',
  styleUrls: ['./contact-reg.component.css']
})
export class ContactRegComponent implements OnInit {


  contact:Contact={Email:"",PhoneNumber:"",PolicyId:"",Message:""}
  constructor(private objsrv:ContactService ) {

   }

  ngOnInit(): void {
  }

  save()
  {
    if(  this.contact.Email=="" || this.contact.PhoneNumber=="" || this.contact.Message=="")
    {
      alert("Please fill all the details")
      return false;
    }
   
    this.objsrv.savecontacts(this.contact).subscribe(res=>{
      console.log(res)
      if (res.status==201){
        alert("Your Record is Saved");
      }
    }),(err => {
      alert("Oops Error ")
    })
    return true;
  
    } 

}
