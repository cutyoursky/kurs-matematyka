import { Component } from '@angular/core';
import { LayoutComponent } from '../../shared/layout/layout.component';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  imports: [LayoutComponent, FormsModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css',
})
export class SignInComponent {
  constructor(private http: HttpClient, private router: Router) {}

  loginObj: any = {
    email: '',
    password: '',
  };

  onSubmit(formData: NgForm) {
    if (formData.invalid) {
      return;
    }

    console.log('Form data:', formData);

    // Submit the form data to the API
    this.http
      .post(
        'http://localhost:5220/api/login',
        {
          email: this.loginObj.email,
          password: this.loginObj.password,
        },
        { responseType: 'text' }
      )
      .subscribe({
        next: (response) => {
          console.log('Response from API:', response);
          localStorage.setItem
          this.router.navigate(['home']);
        },
        error: (error) => {
          console.error('Error from API:', error);
        },
      });
  }
}
