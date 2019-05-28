import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../shared/services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerForm: FormGroup;
  constructor(private fb: FormBuilder,
              private service: AuthService) {
                this.registerForm = fb.group(
                  {
                    userName: ['', Validators.required],
                    userPassword: ['', Validators.required],
                    confirmPassword: ['', Validators.required]
                  }, {validator: matchingFields('userPassword', 'confirmPassword')}
                );
               }
  onSubmit() {
    delete this.registerForm.value.confirmPassword;
    this.service.register(this.registerForm.value).subscribe(
      (data: any) => {
        console.log(data);
        localStorage.setItem('userName', data.userName);
        localStorage.setItem('token', data.Token);
      }
    );
  }
}

function matchingFields(field1: string, filed2: string) {
  return (form: { controls: { [x: string]: { value: any; }; }; }) => {
    if (form.controls[field1].value !== form.controls[filed2].value) {
      return { matchingFields: true };
    }
  };
}
