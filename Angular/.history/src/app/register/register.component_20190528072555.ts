import { Component, NgModule } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { AuthService } from '../shared/services';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from '../login/login-routing.module';
import { MatInputModule, MatCheckboxModule, MatButtonModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  imports: [
      FormsModule,
      CommonModule,
      LoginRoutingModule,
      MatInputModule,
      MatCheckboxModule,
      MatButtonModule,
      FlexLayoutModule.withConfig({addFlexToParent: false})
  ],
  declarations: [RegisterComponent]
})
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerForm: FormGroup;
  constructor(private fb: FormBuilder,
              private service: AuthService) {
                this.registerForm = fb.group({
                  userName: ['', Validators.required],
                  userPassword: ['', Validators.required],
                  confirmPassword: ['', Validators.required],
                }, {validator: matchingFields('password', 'confirmPassword')});
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

function matchingFields(field1: string, field2: string) {
  return form => {
    if (form.controls[field1].value !== form.controls[field2].value) {
     return { matchingFields: true };
    }
  };
}
