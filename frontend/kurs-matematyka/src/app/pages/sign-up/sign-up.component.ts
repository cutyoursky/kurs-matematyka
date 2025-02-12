import { Component, EventEmitter, output, signal } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header.component';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [HeaderComponent, FormsModule],
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent {
  constructor(private http: HttpClient, private router: Router) {}
  
    
  onSubmit(formData: NgForm) {
    // if (formData.invalid) {
    //   return;
    // }

    console.log('Form data:', formData);
    const enteredEmail = formData.form.value.email;
    const enteredPassword = formData.form.value.password;
    const enteredConfirmPassword = formData.form.value.confirmPassword;

    // Submit the form data to the API
    this.http
      .post('http://localhost:5220/api/register', {
        email: enteredEmail,
        password: enteredPassword,
        confirmPassword: enteredConfirmPassword
      }, { responseType: 'text' })
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
