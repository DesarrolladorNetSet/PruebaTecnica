import { Component, OnInit } from '@angular/core';
import { UserService } from '../_service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {
  form: any = {
    name: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  errorMessage = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const { name, email, password } = this.form;

    this.userService.register(name, email, password).subscribe(
      data => {
        console.log(data);
        this.errorMessage = "";
        this.isSuccessful = true;
      },
      err => {
        this.isSuccessful = false;
        this.errorMessage = err.error;
      }
    );
  }
}
