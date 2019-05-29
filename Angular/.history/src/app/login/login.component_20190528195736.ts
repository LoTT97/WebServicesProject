import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/services';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    loginData = {
      userName: '',
      userPassword: ''
    };
    constructor(private service: AuthService,
                private router: Router) {}

    ngOnInit() {}

    onLogin() {
        this.service.login(this.loginData).subscribe(
          (data: any) => {
            console.log(data);
            localStorage.setItem('userName', data.userName);
            localStorage.setItem('token', data.token);
            localStorage.setItem('isLoggedin', 'true');
            this.router.navigate(['/dashboard']);
          },
          (error) => {
            return alert(error.error.Message);
          }
        );
    }

    goToRegister() {
      this.router.navigate(['/register']);
    }
}
