import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticatheService } from '../authenticate/authenticathe.service';

@Component({
  selector: 'app-form-auth',
  templateUrl: './form-auth.component.html',
  styleUrls: ['./form-auth.component.css']
})
export class FormAuthComponent implements OnInit {
  userform: FormGroup;
  constructor(private formBuilder: FormBuilder, private authService: AuthenticatheService) {

  }

  auht(): void {
    this.authService
      .authenticate()
      .subscribe(result => {
        if (result.userName == this.userform["user"] && this.userform["password"] == result.password) {

        }
      });
  }

  ngOnInit(): void {
    this.userform = this.formBuilder.group({
      user: ['', Validators.required],
      password: ['', Validators.required],
      done:false
    });
    
  }

}
