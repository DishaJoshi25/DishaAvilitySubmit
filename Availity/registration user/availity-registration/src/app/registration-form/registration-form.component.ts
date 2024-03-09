import { Component } from '@angular/core';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent {
  formData = {
    firstName: '',
    lastName: '',
    npiNumber: '',
    businessAddress: '',
    telephoneNumber: '',
    emailAddress: ''
  };

  onSubmit() {
    // Send formData to backend for registration process
    console.log('Form submitted:', this.formData);
  }
}
