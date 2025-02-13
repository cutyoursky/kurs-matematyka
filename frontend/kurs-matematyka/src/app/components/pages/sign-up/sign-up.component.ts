import { Component, EventEmitter, output, signal } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { LayoutComponent } from '../../shared/layout/layout.component';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [FormsModule, LayoutComponent],
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent {
  constructor(private http: HttpClient, private router: Router) {}

  registerObj: any = {
    email: '',
    password: '',
    confirmPassword: '',
  };
  // const enteredEmail = formData.form.value.email;
  // const enteredPassword = formData.form.value.password;
  // const enteredConfirmPassword = formData.form.value.confirmPassword;

  onSubmit(formData: NgForm) {
    if (formData.invalid) {
      return;
    }

    // Submit the form data to the API
    this.http
      .post(
        'http://localhost:5220/api/register',
        {
          email: this.registerObj.email,
          password: this.registerObj.password,
          confirmPassword: this.registerObj.confirmPassword,
        },
        { responseType: 'text' }
      )
      .subscribe({
        next: (response) => {
          console.log('Response from API:', response);
          this.router.navigate(['home']);
        },
        error: (error) => {
          console.error('Error from API:', error);
        },
      });
  }
}
