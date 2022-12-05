import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/shared/contact/contact.service';

@Component({
  selector: 'app-contact-reg',
  templateUrl: './contact-reg.component.html',
  styleUrls: ['./contact-reg.component.css']
})
export class ContactRegComponent implements OnInit {


  constructor(private objsrv:ContactService ) { }
contact={PolicyId:0,UserName:"",Email:"",PhoneNumber:"",PolicyType:"",Message:"", }

  ngOnInit(): void {
  }

  save()
  {
    if(this.contact.UserName=="" || this.contact.Email=="" || this.contact.PhoneNumber=="" || this.contact.PhoneNumber=="" || this.contact.Message=="")
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
